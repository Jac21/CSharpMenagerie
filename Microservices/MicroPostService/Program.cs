using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroPostService.Data;
using MicroPostService.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroPostService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ListenForIntegrationEvents();

            CreateHostBuilder(args).Build().Run();
        }

        private static async Task ListenForIntegrationEvents()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var contextOptions = new DbContextOptionsBuilder<PostServiceContext>()
                    .UseSqlite(@"Data Source=post.db")
                    .Options;

                var dbContext = new PostServiceContext(contextOptions);

                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Debug.WriteLine($"[x] received {message}");

                var data = JObject.Parse(message);
                var type = ea.RoutingKey;

                switch (type)
                {
                    case "user.add":
                        dbContext.User.Add(new User
                        {
                            Id = data["id"].Value<int>(),
                            Name = data["name"].Value<string>()
                        });

                        await dbContext.SaveChangesAsync();

                        break;
                    case "user.update":
                        var user = dbContext.User.First(a => a.Id == data["id"].Value<int>());

                        user.Name = data["newname"].Value<string>();

                        await dbContext.SaveChangesAsync();

                        break;
                    case "user.delete":
                        var userToDelete = dbContext.User.First(a => a.Id == data["id"].Value<int>());

                        dbContext.User.Remove(userToDelete);

                        await dbContext.SaveChangesAsync();

                        break;
                    default:
                        Console.WriteLine($"Unknown message: {type}");
                        break;
                }
            };

            channel.BasicConsume("user.postservice", true, consumer);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using static System.Console;

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
                        if (dbContext.User.Any(u => u.Id == data["id"].Value<int>()))
                        {
                            WriteLine("Ignoring old/duplicate entry");
                        }
                        else
                        {
                            dbContext.User.Add(new User
                            {
                                Id = data["id"].Value<int>(),
                                Name = data["name"].Value<string>(),
                                Version = data["version"].Value<int>()
                            });
                        }

                        await dbContext.SaveChangesAsync();

                        break;
                    case "user.update":
                        var newVersion = data["version"].Value<int>();

                        var user = dbContext.User.First(a => a.Id == data["id"].Value<int>());

                        if (user.Version >= newVersion)
                        {
                            WriteLine("Ignoring old/duplicate entity");
                        }
                        else
                        {
                            user.Name = data["newname"].Value<string>();
                            user.Version = newVersion;

                            await dbContext.SaveChangesAsync();
                        }

                        break;
                    case "user.delete":
                        var userToDelete = dbContext.User.First(a => a.Id == data["id"].Value<int>());

                        dbContext.User.Remove(userToDelete);

                        await dbContext.SaveChangesAsync();

                        break;
                    default:
                        WriteLine($"Unknown message: {type}");
                        break;
                }

                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume("user.postservice", false, consumer);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    // clear default logging providers
                    logging.ClearProviders();

                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
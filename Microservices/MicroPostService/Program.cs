using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroPostService.Data;
using MicroPostService.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
            // TODO
            var environment = "Development"; // Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{environment}.json", true, true)
                .Build();

            await ListenForIntegrationEvents(configuration);

            CreateHostBuilder(args).Build().Run();
        }

        private static async Task ListenForIntegrationEvents(IConfiguration configuration)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var connectionStringsList = new List<string>();

                ConnectionUtilities.CreateConnectionStringsListFromConfiguration(configuration, connectionStringsList);

                // TODO - Figure out which shard to utilize from event/message
                var dbContext =
                    new PostServiceContext(ConnectionUtilities.GetConnectionString(connectionStringsList, "Main"));

                await HandleReceivedEventsPerContext(ea, dbContext);

                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume("user.postservice", false, consumer);
        }

        private static async Task HandleReceivedEventsPerContext(BasicDeliverEventArgs ea, PostServiceContext dbContext)
        {
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
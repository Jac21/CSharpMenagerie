using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;

namespace ConnectionStringValidation.Configuration;

public class ConnectionStrings
    : Dictionary<string, string>
{
    public ConnectionStrings()
    {
        DbProviderFactories.RegisterFactory("Sqlite", SqliteFactory.Instance);
        DbProviderFactories.RegisterFactory("SqlServer", SqlClientFactory.Instance);
    }

    public bool Validate()
    {
        var logger = LoggerFactory
            .Create(cfg => cfg
                .AddConsole()
                .AddDebug())
            .CreateLogger("ConnectionStrings");

        var errors = new List<Exception>();

        foreach (var (key, connectionString) in this)
        {
            try
            {
                var factory = DbProviderFactories.GetFactory(key);

                using var connection = factory.CreateConnection();

                if (connection is null)
                {
                    throw new Exception($"\"{key}\" did not have a valid database provider registered");
                }

                connection.ConnectionString = connectionString;
                connection.Open();
            }
            catch (Exception ex)
            {
                var message = $"Could not connect to \"{key}\".";

                // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
                logger.LogError(message);
                errors.Add(new Exception(message, ex));
            }
        }

        return errors.IsNullOrEmpty();
    }
}
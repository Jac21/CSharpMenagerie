using Microsoft.Extensions.Options;

namespace ConnectionStringValidation.Configuration;

public static class ConnectionStringExtensions
{
    public static OptionsBuilder<ConnectionStrings> ValidateConnectionStrings(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddOptions<ConnectionStrings>()
            .BindConfiguration("ConnectionStrings")
            .Validate(c => c.Validate(), "Could not connect to one or more databases");
    }
}
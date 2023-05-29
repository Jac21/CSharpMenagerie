using FeatureManagement;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        // add feature management with time-basesd filtering
        services.AddFeatureManagement()
            .AddFeatureFilter<TimeWindowFilter>();
    })
    .Build();

host.Run();
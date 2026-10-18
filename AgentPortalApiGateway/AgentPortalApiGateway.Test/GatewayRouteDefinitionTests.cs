using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using AgentPortalApiGateway.Api;
using Xunit;

namespace AgentPortalApiGateway.Test;

public class GatewayRouteDefinitionTests
{
    [Fact]
    public void OcelotRoutesDefineCompleteAndUniqueApiContracts()
    {
        var configurationPath = Path.Combine(AppContext.BaseDirectory, "ocelot.json");
        using var configurationStream = File.OpenRead(configurationPath);
        var configuration = JsonSerializer.Deserialize<GatewayConfiguration>(
            configurationStream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        Assert.NotNull(configuration);
        Assert.NotEmpty(configuration.Routes);
        Assert.All(configuration.Routes, route =>
        {
            Assert.False(string.IsNullOrWhiteSpace(route.UpstreamPathTemplate));
            Assert.False(string.IsNullOrWhiteSpace(route.DownstreamPathTemplate));
            Assert.False(string.IsNullOrWhiteSpace(route.ServiceName));
            Assert.NotEmpty(route.UpstreamHttpMethod);
        });

        var routeKeys = configuration.Routes
            .SelectMany(route => route.UpstreamHttpMethod.Select(method =>
                $"{method}:{route.UpstreamPathTemplate}"))
            .ToArray();

        Assert.Equal(routeKeys.Length, routeKeys.Distinct(StringComparer.OrdinalIgnoreCase).Count());
    }
}

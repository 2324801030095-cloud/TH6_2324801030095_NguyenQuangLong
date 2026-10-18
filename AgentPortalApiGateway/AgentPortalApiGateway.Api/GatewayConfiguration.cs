using System;
using System.Collections.Generic;

namespace AgentPortalApiGateway.Api;

public sealed class GatewayConfiguration
{
    public IReadOnlyList<GatewayRouteDefinition> Routes { get; init; } = Array.Empty<GatewayRouteDefinition>();
}

public sealed class GatewayRouteDefinition
{
    public string UpstreamPathTemplate { get; init; } = string.Empty;

    public string DownstreamPathTemplate { get; init; } = string.Empty;

    public string ServiceName { get; init; } = string.Empty;

    public IReadOnlyList<string> UpstreamHttpMethod { get; init; } = Array.Empty<string>();
}

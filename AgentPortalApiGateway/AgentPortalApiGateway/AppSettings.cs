namespace AgentPortalApiGateway;

public class AppSettings
{
    public string[] AllowedChatOrigins { get; set; } = new[]
    {
        "http://localhost:8080",
        "http://localhost:5081"
    };
}

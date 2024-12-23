namespace SpiderAI.Core.Configuration;

public class AzureOpenAI()
{
    public string ApiKey { get; set; } = string.Empty;
    public string Endpoint { get; set; } = string.Empty;
    public Model[] Models { get; set; } = [];
}
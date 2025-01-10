using SpiderAI.Client.Shared.Services;

namespace SpiderAI.Client.Web.Services;
public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "Web";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}

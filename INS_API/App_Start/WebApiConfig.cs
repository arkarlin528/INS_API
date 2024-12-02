using System.Web.Http;
using System.Web.Http.Cors;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Enable CORS globally
        config.EnableCors();

        // Other Web API configuration code...
    }
}
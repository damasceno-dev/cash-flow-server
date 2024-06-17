using System.Globalization;

namespace CashFlow.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var requestedCulture= context.Request.Headers.AcceptLanguage.FirstOrDefault();
        
        CultureInfo cultureInfo;
        try
        {
            cultureInfo = new CultureInfo(requestedCulture ?? "en");
        }
        catch (CultureNotFoundException)
        {
            cultureInfo = CultureInfo.InvariantCulture; // Fallback to invariant culture
        }
        
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
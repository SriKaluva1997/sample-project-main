using System.Net.Http;
using System.Net;
using System.Web.Http.Filters;

public class GlobalExceptionFilter : ExceptionFilterAttribute
{
    public override void OnException(HttpActionExecutedContext context)
    {
        // Log error
        var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent("Something went wrong."),
            ReasonPhrase = "Critical Exception"
        };
        context.Response = response;
    }
}
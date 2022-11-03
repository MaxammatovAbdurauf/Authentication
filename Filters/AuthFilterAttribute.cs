using Authorisation.DataBase;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Authorisation.Filters;

public class AuthFilterAttribute : ActionFilterAttribute 
{
    private readonly UserDB db;
    public AuthFilterAttribute()
    {

    }

    public AuthFilterAttribute (UserDB _db)
    {
        db = _db;
    }
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Response.Headers.ContainsKey("Key"))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.HttpContext.Response.WriteAsync("Unathorised");
            return;
        };
        var key =  context.HttpContext.Response.Headers["Key"];
        var user = db.Users.FirstOrDefault(x => x.Key == key);

        if (user == null)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.HttpContext.Response.WriteAsync("Unathorised");
        }

    }
}

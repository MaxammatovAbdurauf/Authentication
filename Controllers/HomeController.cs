using Authorisation.Filters;
using Microsoft.AspNetCore.Mvc;
using Authorisation.DataBase;
using Authorisation.Model;

namespace Authorisation.Controllers;
[Route ("[Controller]")]
[ApiController]

public class HomeController : Controller
{
    private readonly UserDB userdb;

    public HomeController (UserDB _userdb)
    {
        userdb = _userdb;
    }
    [HttpGet]
    [TypeFilter(typeof(AuthFilterAttribute))]
    public IActionResult Index(int k, int n)
    {
        string str = "";
        int count = 0;
        for (int i = 1; i < n + 1; i++) str += i.ToString();
        for (int j = 0;  j < str.Length; j++) if (str[j] == Convert.ToChar(k.ToString())) count++;
        return Ok(count);
    }
    [HttpPost]
    public IActionResult RegistrUser (GetUser getUser)
    {
        var key = Guid.NewGuid().ToString("N").Substring(10);
        var user = new User()
        {
            Name = getUser.Name,
            Password = getUser.Password,
            Key = key,
        };
        userdb.Users.Add(user);
        userdb.SaveChanges();
        return Ok(key);
    }
}
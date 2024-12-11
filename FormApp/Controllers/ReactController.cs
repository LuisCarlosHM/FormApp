using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ReactController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return File("~/react/index.html", "text/html");
    }
}

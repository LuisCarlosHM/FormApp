using Microsoft.AspNetCore.Mvc;

public class ReactController : Controller
{
    public IActionResult Index()
    {
        return File("~/react/index.html", "text/html");
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{


    // GET: /HelloWorld/Welcome/ 
    // Requires using System.Text.Encodings.Web;
    public IActionResult Index()
    {
        return View();
    }

}
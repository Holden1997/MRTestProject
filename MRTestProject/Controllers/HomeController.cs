using Microsoft.AspNetCore.Mvc;
using MRTestProject.Domain;
using MRTestProject.Extensions;
using MRTestProject.Models;

namespace MRTestProject.Controllers
{

    public class HomeController : Controller
    {
        
        [ActionName("index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
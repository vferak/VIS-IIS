using DomainLayer.Engine;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(Connection connection) : base(connection) {}

        public IActionResult Index()
        {
            return View();
        }
    }
}
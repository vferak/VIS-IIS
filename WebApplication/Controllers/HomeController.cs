using DomainLayer.Engine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(Connection connection, IConfiguration config) : base(connection, config) {}

        public IActionResult Index()
        {
            return View();
        }
    }
}
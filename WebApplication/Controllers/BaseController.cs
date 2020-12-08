using DomainLayer.Engine;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public Connection Connection { get; set; }
        
        public BaseController(Connection connection)
        {
            Connection = connection;
        }
    }
}
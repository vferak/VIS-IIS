using DomainLayer.Engine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class BaseController : Controller
    {
        public Connection Connection { get; set; }
        
        public IConfiguration Config { get; set; }
        
        public BaseController(Connection connection, IConfiguration config)
        {
            Connection = connection;
            Config = config;
        }
    }
}
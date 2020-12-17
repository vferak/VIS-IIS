using DomainLayer.Engine;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class ClientsController : BaseController
    {
        public ClientsController(Connection connection, IConfiguration config) : base(connection, config) {}

        private ActionResult ProcessForm(Clients client)
        {
            client.Save();
            return RedirectToAction("Show", "Clients", new {modelId = client.LoadOne().ModelId});
        }
        
        public ActionResult Index()
        {
            ViewBag.Clients = new Clients(Connection).Load();
            return View();
        }

        public ActionResult Show(int modelId)
        {
            var client = new Clients(Connection) {ModelId = modelId}.LoadOne();
            if (client == null) return NotFound();

            ViewBag.Client = client;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Clients client)
        {
            return ModelState.IsValid ? ProcessForm(client) : Create();
        }

        public ActionResult Update(int? modelId)
        {
            var client = new Clients(Connection) {ModelId = modelId}.LoadOne();
            if (client == null) return NotFound();

            ViewBag.Client = client;
            return View();
        }
        
        [HttpPost]
        public ActionResult Update(Clients client)
        {
            return ModelState.IsValid ? ProcessForm(client) : Update(client.ModelId);
        }
        
        public ActionResult Destroy(int modelId)
        {
            var client = new Clients(Connection) {ModelId = modelId}.LoadOne();
            if (client == null) return NotFound();

            client.Delete();
            return RedirectToAction("Index");
        }
    }
}
using DomainLayer.Engine;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ClientsController : BaseController
    {
        public ClientsController(Connection connection) : base(connection) {}

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
            // if (client == null) return HttpNotFound();

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
            // if (client == null) return HttpNotFound();

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
            // if (client == null) return HttpNotFound();

            client.Delete();
            return RedirectToAction("Index");
        }
    }
}
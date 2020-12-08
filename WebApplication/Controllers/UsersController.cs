using DomainLayer.Engine;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(Connection connection) : base(connection) {}

        private ActionResult ProcessForm(Users user)
        {
            user.Save();
            return RedirectToAction("Show", "Users", new {modelId = user.LoadOne().ModelId});
        }
        
        public ActionResult Index()
        {
            ViewBag.Users = new Users(Connection).Load();
            return View();
        }

        public ActionResult Show(int modelId)
        {
            var user = new Users(Connection) {ModelId = modelId}.LoadOne();
            // if (user == null) return HttpNotFound();

            ViewBag.User = user;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Users user)
        {
            return ModelState.IsValid ? ProcessForm(user) : Create();
        }

        public ActionResult Update(int? modelId)
        {
            var user = new Users(Connection) {ModelId = modelId}.LoadOne();
            // if (user == null) return HttpNotFound();

            ViewBag.User = user;
            return View();
        }
        
        [HttpPost]
        public ActionResult Update(Users user)
        {
            return ModelState.IsValid ? ProcessForm(user) : Update(user.ModelId);
        }
        
        public ActionResult Destroy(int modelId)
        {
            var user = new Users(Connection) {ModelId = modelId}.LoadOne();
            // if (user == null) return HttpNotFound();

            user.Delete();
            return RedirectToAction("Index");
        }
    }
}
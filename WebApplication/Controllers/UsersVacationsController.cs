using DomainLayer.Engine;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class UsersVacationsController : BaseController
    {
        public UsersVacationsController(Connection connection, IConfiguration config) : base(connection, config) {}

        private ActionResult ProcessForm(UsersVacations userVacation)
        {
            userVacation.Save();
            return RedirectToAction("Show", "UsersVacations", new {modelId = userVacation.LoadOne().ModelId});
        }
        
        public ActionResult Index()
        {
            ViewBag.UsersVacations = new UsersVacations(Connection).Load();
            return View();
        }

        public ActionResult Show(int modelId)
        {
            var userVacation = new UsersVacations(Connection) {ModelId = modelId}.LoadOne();
            if (userVacation == null) return NotFound();

            ViewBag.UserVacation = userVacation;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(UsersVacations userVacation)
        {
            userVacation.UserModelId = Config.GetValue<int>("LoggedUser");
            ModelState.Clear();
            TryValidateModel(userVacation);
            return ModelState.IsValid ? ProcessForm(userVacation) : Create();
        }

        public ActionResult Update(int? modelId)
        {
            var userVacation = new UsersVacations(Connection) {ModelId = modelId}.LoadOne();
            if (userVacation == null) return NotFound();

            ViewBag.UserVacation = userVacation;
            return View();
        }
        
        [HttpPost]
        public ActionResult Update(UsersVacations userVacation)
        {
            return ModelState.IsValid ? ProcessForm(userVacation) : Update(userVacation.ModelId);
        }
        
        public ActionResult Destroy(int modelId)
        {
            var userVacation = new UsersVacations(Connection) {ModelId = modelId}.LoadOne();
            if (userVacation == null) return NotFound();

            userVacation.Delete();
            return RedirectToAction("Index");
        }

        public IActionResult Accept(int? modelId)
        {
            var userVacation = new UsersVacations(Connection) {ModelId = modelId}.LoadOne();
            if (userVacation == null) return NotFound();

            userVacation.Accept();
            return RedirectToAction("Index");
        }
    }
}
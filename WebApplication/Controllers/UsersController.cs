using System.Collections.Generic;
using System.Linq;
using DomainLayer.Engine;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(Connection connection, IConfiguration config) : base(connection, config) {}

        private ActionResult ProcessForm(Users user)
        {
            user.Save();
            return RedirectToAction("Show", "Users", new {modelId = user.LoadOne().ModelId});
        }

        private IEnumerable<SelectListItem> GetSeniorsSelectList()
        {
            return new Users(Connection).LoadSeniors().Select(i => new SelectListItem
            {
                Value = i.ModelId.ToString(),
                Text = i.GetFullName()
            }).ToList();
        }

        public ActionResult Index()
        {
            ViewBag.Users = new Users(Connection).Load();
            return View();
        }

        public ActionResult Show(int modelId)
        {
            var user = new Users(Connection) {ModelId = modelId}.LoadOne();
            if (user == null) return NotFound();

            ViewBag.User = user;
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Seniors = GetSeniorsSelectList();
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
            if (user == null) return NotFound();

            ViewBag.User = user;
            ViewBag.Seniors = GetSeniorsSelectList();
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
            if (user == null) return NotFound();

            user.Delete();
            return RedirectToAction("Index");
        }

        public IActionResult Promote(int? modelId)
        {
            var user = new Users(Connection) {ModelId = modelId}.LoadOne();
            if (user == null) return NotFound();

            user.Promote();
            return RedirectToAction("Index");
        }
    }
}
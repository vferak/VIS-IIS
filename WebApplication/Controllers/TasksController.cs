using System.Collections.Generic;
using System.Linq;
using DomainLayer.Engine;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class TasksController : BaseController
    {
        public TasksController(Connection connection, IConfiguration config) : base(connection, config) {}

        private ActionResult ProcessForm(Tasks task)
        {
            task.Save();
            return RedirectToAction("Show", "Tasks", new {modelId = task.LoadOne().ModelId});
        }
        
        private IEnumerable<SelectListItem> GetRatesSelectList()
        {
            var result = new Tasks(Connection).GetRates().Select(i => new SelectListItem
            {
                Value = i.Value.ToString(),
                Text = i.Key
            }).ToList();

            return result;
        }
        
        private IEnumerable<SelectListItem> GetStatusesSelectList(string status = null)
        {
            return new TasksEvents(Connection).GetStatuses().Select(i => new SelectListItem
            {
                Value = i.Value.ToString(),
                Text = i.Key,
                Selected = status != null && status == i.Value
            }).ToList();
        }
        
        private IEnumerable<SelectListItem> GetClientsSelectList()
        {
            return new Clients(Connection).Load().Select(i => new SelectListItem
            {
                Value = i.ModelId.ToString(),
                Text = i.Name
            }).ToList();
        }
        
        public ActionResult Index()
        {
            ViewBag.Tasks = new Tasks(Connection).Load();
            return View();
        }

        public ActionResult Show(int modelId)
        {
            var task = new Tasks(Connection) {ModelId = modelId}.LoadOne();
            if (task == null) return NotFound();

            ViewBag.Task = task;
            ViewBag.TaskEvents = task.GetTasksEvents().Reverse();
            ViewBag.Statuses = GetStatusesSelectList(task.GetStatus());
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Rates = GetRatesSelectList();
            ViewBag.Clients = GetClientsSelectList();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Tasks task)
        {
            task.UserModelId = Config.GetValue<int>("LoggedUser");
            ModelState.Clear();
            TryValidateModel(task);
            return ModelState.IsValid ? ProcessForm(task) : Create();
        }

        public ActionResult Update(int? modelId)
        {
            var task = new Tasks(Connection) {ModelId = modelId}.LoadOne();
            if (task == null) return NotFound();

            ViewBag.Task = task;
            ViewBag.Rates = GetRatesSelectList();
            ViewBag.Clients = GetClientsSelectList();
            return View();
        }
        
        [HttpPost]
        public ActionResult Update(Tasks task)
        {
            return ModelState.IsValid ? ProcessForm(task) : Update(task.ModelId);
        }
        
        public ActionResult Destroy(int modelId)
        {
            var task = new Tasks(Connection) {ModelId = modelId}.LoadOne();
            if (task == null) return NotFound();

            task.Delete();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateEvent(TasksEvents taskEvent)
        {
            taskEvent.UserModelId = Config.GetValue<int>("LoggedUser");
            ModelState.Clear();
            TryValidateModel(taskEvent);

            if (ModelState.IsValid)
            {
                taskEvent.Save();
            }
            
            return RedirectToAction("Show", new {modelId = taskEvent.TaskModelId});
        }
    }
}
using EF_Tasks_Data;
using Microsoft.AspNetCore.Mvc;
using Tasks.Business;
using TasksTODO.Models;

namespace TasksTODO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private ITaskService _tasksService;

        public TaskController(ITaskService taskService)
        {
            _tasksService = taskService;
        }
        [HttpGet("/read")]
        public IActionResult ReadTasks()
        {
            var temp = _tasksService.ReadTasks();
            List<TasksModel> a = new List<TasksModel>(); 
            foreach (var item in temp)
            {
                a.Add(new TasksModel
                {
                    TaskID = item.TaskID,
                    TaskTheme = item.TaskTheme,
                    Description = item.Description,
                    DeadLine = item.DeadLine,
                    CheckComplete = item.CheckComplete
                });
            }
            return View("View", a);
        }

        [HttpGet("/create")]
        public IActionResult GetCreate()
        {
            return View("Create");
        }
        [HttpPost("/createcomplete")]
        public IActionResult PostCreate([FromForm] string TaskTheme, [FromForm] string Description, [FromForm] DateTime DeadLine)
        {
            _tasksService.CreateTasks(TaskTheme, Description, DeadLine);
            return RedirectToAction("ReadTasks");
        }
        [HttpGet("/delete/{id:int}")]
        public IActionResult GetDelete(int id)
        {
            var temp = _tasksService.GetById(id);
            TasksModel a = new TasksModel
            {
                TaskID = temp.TaskID,
                TaskTheme = temp.TaskTheme,
                Description = temp.Description,
                DeadLine = temp.DeadLine,
                CheckComplete = temp.CheckComplete
            };
            return View("Delete", a);
        }
        [HttpPost("/deletecomplete")]
        public IActionResult PostDelete([FromForm] TasksModel d)
        {
            _tasksService.DeleteTasks(d.TaskID);
            return RedirectToAction("ReadTasks");
        }
        [HttpGet("/update/{id:int}")]
        public IActionResult GetUpdate(int id)
        {
            var temp = _tasksService.GetById(id);
            TasksModel a = new TasksModel
            {
                TaskID = temp.TaskID,
                TaskTheme = temp.TaskTheme,
                Description = temp.Description,
                DeadLine = temp.DeadLine,
                CheckComplete = temp.CheckComplete
            };
            return View("Update", a);
        }
        [HttpPost("/updatecomplete")]
        public IActionResult PostUpdate([FromForm] TasksModel d)
        {
            _tasksService.UpdateTasks(d.TaskID, d.TaskTheme, d.Description, d.DeadLine);
            return RedirectToAction("ReadTasks");
        }
        [HttpPut("{taskId}/complete")]
        public IActionResult UpdateCompleteStatus(int taskId)
        {
            _tasksService.CheckComplete(taskId);
            return new EmptyResult();
        }

    }
}

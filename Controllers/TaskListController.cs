using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListProject.Data;
using ToDoListProject.Models;

namespace ToDoListProject.Controllers
{
    public class TaskListController : Controller
    {
        private readonly DatabaseContext databaseContext;
        public TaskListController(DatabaseContext databaseContext)
        {
           this.databaseContext= databaseContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddTaskModel TaskModel)
        {
            var task = new TaskList
            {
                TaskDescription = TaskModel.TaskDescription,
                Status = TaskModel.Status,
            };
            await databaseContext.MyProperty.AddAsync(task);
            await databaseContext.SaveChangesAsync();
            return View();
        }

        [HttpGet]
       public async Task<IActionResult> List()
        {
            var tasks = await databaseContext.MyProperty.ToListAsync();
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await databaseContext.MyProperty.FindAsync(id);
            return View(task);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TaskList model)
        {
            var task=await databaseContext.MyProperty.FindAsync(model.TaskId);
            if(task is not  null)
            {
                task.TaskDescription = model.TaskDescription;
                task.Status = model.Status;

                await databaseContext.SaveChangesAsync();
               
            }
            return RedirectToAction("List","TaskList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TaskList model)
        {
            var task = await databaseContext.MyProperty.FindAsync(model.TaskId);
            if ((task is not null))
            {
                databaseContext.MyProperty.Remove(task);
                databaseContext.SaveChanges();

            }
            return RedirectToAction("List", "TaskList");
        }
        }

}

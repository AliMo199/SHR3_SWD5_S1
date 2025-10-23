using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TaskController : Controller
    {
        ITaskRepository TaskRepository;
        public TaskController(ITaskRepository TaskRepo)
        {
            this.TaskRepository = TaskRepo;
        }

        public ActionResult Index()
        {
            List<TaskItem> tasks = TaskRepository.GetAll().OrderByDescending(t=>t.DueDate).ToList();
            return View(tasks);
        }

        public ActionResult Details(int id)
        {
            TaskItem task = TaskRepository.GetbyId(id);
            return View(task);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskItem Task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskRepository.Create(Task);
                    return RedirectToAction(nameof(Index));
                }
                return View(Task);
            }
            catch
            {
                return View(Task);
            }
        }


        public ActionResult Edit(int id)
        {
            TaskItem task = TaskRepository.GetbyId(id);
            return View(task);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskItem Task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaskItem ExistingTask = TaskRepository.GetbyId(id);
                    if (ExistingTask != null)
                    {
                        ExistingTask.Title = Task.Title;
                        ExistingTask.Description = Task.Description;
                        ExistingTask.IsCompleted = Task.IsCompleted;
                        ExistingTask.DueDate = Task.DueDate;
                        TaskRepository.Update(ExistingTask);
                        return RedirectToAction(nameof(Index));
                    }
                    return NotFound();
                }
                return View(Task);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            TaskItem task = TaskRepository.GetbyId(id);
            if(task != null)
            {
                TaskRepository.Delete(task);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}

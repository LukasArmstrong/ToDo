using ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ToDo.ViewModels;
using System.Net;
using System.Data.Entity.Infrastructure;
using ToDo.Data;

namespace ToDo.Controllers
{
    /// <summary>
    /// Controller for the "Comic Books" section of the website.
    /// </summary>
    public class TasksController : Controller
    {
        private Context _context = null;
        public TasksController()
        {
            _context = new Context();
        }
        public ActionResult Index()
        {
            // TODO Get the comic books list.
            // Include the "Series" navigation property.
            var task = _context.Tasks
                    .Include(t => t.List)
                    .OrderBy(t => t.List.Title)
                    .ThenBy(t => t.OrderNumber)
                    .ToList();

            return View(task);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the comic book.
            // Include the "Series", "Artists.Artist", and "Artists.Role" navigation properties.
            var task = _context.Tasks
                    .Include(t => t.List)
                    .Where(t => t.Id == id)
                    .SingleOrDefault(); ;

            if (task == null)
            {
                return HttpNotFound();
            }
            

            return View(task);
        }

        public ActionResult Add()
        {
            var viewModel = new TasksAddViewModel();

            // TODO Pass the Context class to the view model "Init" method.
            viewModel.Init(_context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(TasksAddViewModel viewModel)
        {
            ValidateTasks(viewModel.Task);

            if (ModelState.IsValid)
            {
                var task = viewModel.Task;
                _context.Tasks.Add(task);
                _context.SaveChanges();

                TempData["Message"] = "Your task was successfully added!";

                return RedirectToAction("Detail", new { id = task.Id });
            }

            // TODO Pass the Context class to the view model "Init" method.
            viewModel.Init(_context);

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var task = _context.Tasks
                .Where(t => t.Id == id)
                .SingleOrDefault();

            if (task == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TasksEditViewModel()
            {
                Task = task
            };
            viewModel.Init(_context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TasksEditViewModel viewModel)
        {
            ValidateTasks(viewModel.Task);

            if (ModelState.IsValid)
            {
                var task = viewModel.Task;

                _context.Entry(task).State = EntityState.Modified;
                _context.SaveChanges();

                TempData["Message"] = "Your task was successfully updated!";

                return RedirectToAction("Detail", new { id = task.Id });
            }

            viewModel.Init(_context);

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var task = _context.Tasks
                .Include(t => t.List)
                .Where(t => t.Id == id)
                .SingleOrDefault();


            if (task == null)
            {
                return HttpNotFound();
            }

            return View(task);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var task = new Task() { Id = id };
            _context.Entry(task).State = EntityState.Deleted;
            _context.SaveChanges();

            TempData["Message"] = "Your task was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates a comic book on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="comicBook">The comic book to validate.</param>
        private void ValidateTasks(Task task)
        {
            // If there aren't any "SeriesId" and "IssueNumber" field validation errors...
            if (ModelState.IsValidField("Task.SeriesId") &&
                ModelState.IsValidField("Task.OrderNumber"))
            {
                // Then make sure that the provided issue number is unique for the provided series.
                // TODO Call method to check if the issue number is available for this comic book.
                if (_context.Tasks
                        .Any(t => t.Id != task.Id &&
                                   t.SeriesId == task.SeriesId &&
                                   t.OrderNumber == task.OrderNumber))
                {
                    ModelState.AddModelError("Task.OrderNumber",
                        "The provided order number has already been entered for the selected list.");
                }
            }
        }
    }
}
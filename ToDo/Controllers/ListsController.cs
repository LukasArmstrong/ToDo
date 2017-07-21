using ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ToDo.Controllers
{
    /// <summary>
    /// Controller for the "Series" section of the website.
    /// </summary>
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            // TODO Get the series list.
            var list = new List<List>();

            return View(list);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the series.
            var list = new List();

            if (list == null)
            {
                return HttpNotFound();
            }

            // Sort the comic books.
            list.Tasks = list.Tasks
                .OrderByDescending(t => t.OrderNumber)
                .ToList();

            return View(list);
        }

        public ActionResult Add()
        {
            var list = new List();

            return View(list);
        }

        [HttpPost]
        public ActionResult Add(List list)
        {

            if (ModelState.IsValid)
            {
                // TODO Add the series.

                TempData["Message"] = "Your series was successfully added!";

                return RedirectToAction("Detail", new { id = list.Id });
            }

            return View(list);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the series.
            var list = new List();

            if (list == null)
            {
                return HttpNotFound();
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Edit(List list)
        {

            if (ModelState.IsValid)
            {
                // TODO Update the series.

                TempData["Message"] = "Your list was successfully updated!";

                return RedirectToAction("Detail", new { id = list.Id });
            }

            return View(list);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the series.
            var list = new List();

            if (list == null)
            {
                return HttpNotFound();
            }

            return View(list);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // TODO Delete the series.

            TempData["Message"] = "Your list was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates a series on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="series">The series to validate.</param>
        
    }
}
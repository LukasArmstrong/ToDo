using ToDo.Data;
using ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.ViewModels
{
    /// <summary>
    /// Base view model class for the "Add Comic Book" 
    /// and "Edit Comic Book" views.
    /// </summary>
    public abstract class TasksBaseViewModel
    {
        public Task Task { get; set; } = new Task();

        public SelectList ListSelectListItems { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public virtual void Init(Context context)
        {
            ListSelectListItems = new SelectList(
                context.List.OrderBy(s => s.Title).ToList(),
                "Id", "Title");
        }
    }
}
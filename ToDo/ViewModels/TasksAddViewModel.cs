using ToDo.Data;
using ToDo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToDo.ViewModels
{
    /// <summary>
    /// View model for the "Add Comic Book" view.
    /// </summary>
    public class TasksAddViewModel
        : TasksBaseViewModel
    {
        public TasksAddViewModel()
        {
            // Set the comic book default values.
            Task.OrderNumber = 1;
            Task.CompletedOn = DateTime.Today;
        }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public override void Init(Context context)
        {
            base.Init(context);
        }
    }
}
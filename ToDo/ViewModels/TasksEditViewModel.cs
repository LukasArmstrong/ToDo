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
    /// View model for the "Edit Comic Book" view.
    /// </summary>
    public class TasksEditViewModel 
        : TasksBaseViewModel
    {
        /// <summary>
        /// This property enables model binding to be able to bind the "id"
        /// route parameter value to the "ComicBook.Id" model property.
        /// </summary>
        public int Id
        {
            get { return Task.Id; }
            set { Task.Id = value; }
        }
    }
}
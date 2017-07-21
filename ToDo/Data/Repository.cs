using ToDo.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace ToDo.Data
{
    /// <summary>
    /// Repository class that provides various database queries
    /// and CRUD operations.
    /// </summary>
    public static class Repository
    {
        /// <summary>
        /// Private method that returns a database context.
        /// </summary>
        /// <returns>An instance of the Context class.</returns>
        static Context GetContext()
        {
            var context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }

        /// <summary>
        /// Returns a count of the comic books.
        /// </summary>
        /// <returns>An integer count of the comic books.</returns>
        public static int GetTaskCount()
        {
            using (Context context = GetContext())
            {
                return context.Tasks.Count();
            }
        }

        /// <summary>
        /// Returns a list of comic books ordered by the series title 
        /// and issue number.
        /// </summary>
        /// <returns>An IList collection of ComicBook entity instances.</returns>
        public static IList<Task> GetTasks()
        {
            using (Context context = GetContext())
            {
                return context.Tasks
                    .Include(t => t.List)
                    .OrderBy(t => t.List.Title)
                    .ThenBy(t => t.OrderNumber)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a single comic book.
        /// </summary>
        /// <param name="comicBookId">The comic book ID to retrieve.</param>
        /// <returns>A fully populated ComicBook entity instance.</returns>
        public static Task GetTask(int taskId)
        {
            using (Context context = GetContext())
            {
                return context.Tasks
                    .Include(t => t.List)
                    .Where(t => t.Id == taskId)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Returns a list of series ordered by title.
        /// </summary>
        /// <returns>An IList collection of Series entity instances.</returns>
        public static IList<List> GetList()
        {
            using (Context context = GetContext())
            {
                return context.List
                    .OrderBy(s => s.Title)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a single series.
        /// </summary>
        /// <param name="seriesId">The series ID to retrieve.</param>
        /// <returns>A Series entity instance.</returns>
        public static List GetList(int ListId)
        {
            using (Context context = GetContext())
            {
                return context.List
                    .Where(s => s.Id == ListId)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Returns a list of artists ordered by name.
        /// </summary>
        /// <returns>An IList collection of Artist entity instances.</returns>
        

        /// <summary>
        /// Returns a list of roles ordered by name.
        /// </summary>
        /// <returns>An IList collection of Role entity instances.</returns>
       

        /// <summary>
        /// Adds a comic book.
        /// </summary>
        /// <param name="comicBook">The ComicBook entity instance to add.</param>
        public static void AddTask(Task task)
        {
            using (Context context = GetContext())
            {
                context.Tasks.Add(task);

                if (task.List != null && task.List.Id > 0)
                {
                    context.Entry(task.List).State = EntityState.Unchanged;
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a comic book.
        /// </summary>
        /// <param name="comicBook">The ComicBook entity instance to update.</param>
        public static void UpdateTask(Task task)
        {
            using (Context context = GetContext())
            {
                context.Tasks.Attach(task);
                var comicBookEntry = context.Entry(task);
                comicBookEntry.State = EntityState.Modified;
                //comicBookEntry.Property("IssueNumber").IsModified = false;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a comic book.
        /// </summary>
        /// <param name="comicBookId">The comic book ID to delete.</param>
        public static void Deletetask(int taskId)
        {
            using (Context context = GetContext())
            {
                var task = new Task() { Id = taskId };
                context.Entry(task).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}

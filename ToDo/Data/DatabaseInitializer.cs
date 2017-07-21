using ToDo.Models;
using System;
using System.Data.Entity;

namespace ToDo.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            // This is our database's seed data...
            // 3 series, 6 artists, 2 roles, and 9 comic books.

            var listHome = new List()
            {
                Title = "Get Milk!",
                Description = "Stuff I need to get done around the house."
            };
            var listWork = new List()
            {
                Title = "Do Treehouse things!"
            };

            var task1 = new Task()
            {
                List = listHome,
                OrderNumber = 1,
                Description = "You're a dead man if you don't get the milk!",
                CompletedOn = new DateTime(2017, 7, 25),
            };
            context.Tasks.Add(task1);

            context.SaveChanges();
        }
    }
}

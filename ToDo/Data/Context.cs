using ToDo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ToDo.Data
{
    /// <summary>
    /// Entity Framework context class.
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<List> List { get; set; }
        
    }
}

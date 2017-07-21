using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    /// <summary>
    /// Represents a comic book series.
    /// </summary>
    public class List
    {
        public List()
        {
            Tasks = new List<Task>();
        }

        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}

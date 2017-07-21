using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    /// <summary>
    /// Represents a comic book.
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        [Display(Name ="List")]
        public int SeriesId { get; set; }
        [Display(Name ="Order Number")]
        public int OrderNumber { get; set; }
        public string Description { get; set; }
        [Display(Name = "Completed On")]
        public DateTime CompletedOn { get; set; }

        public List List { get; set; }

        /// <summary>
        /// The display text for a comic book.
        /// </summary>
        public string DisplayText
        {
            get
            {
                return $"{List?.Title}";
            }
        }
    }
}

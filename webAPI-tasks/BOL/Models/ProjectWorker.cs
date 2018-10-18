using _01_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    class ProjectWorker
    {
        public User user { get; set; }
        public int UserId { get; set; }
        public Project project { get; set; }
        public int ProjectId { get; set; }

    }
}

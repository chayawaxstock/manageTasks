using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL.Models
{
    class HourForDepartment
    {
        public Project project { get; set; }
        public int ProjectId { get; set; }
        public DepartmentUser DepartmentUser { get; set; }
        public int DepartmentId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "sum hours must be more than 0 hours")]
        public int SumHours { get; set; }
    }
}

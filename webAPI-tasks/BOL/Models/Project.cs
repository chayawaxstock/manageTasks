﻿
using _01_BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
     public class Project
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15,ErrorMessage = "ProjectName grade than 15 chars"),MinLength(2,ErrorMessage = "ProjectName less than 2 chars")]

        public string ProjectName { get; set; }

        [Required(ErrorMessage = "CustomerName is required")]
        [MaxLength(15, ErrorMessage = "CustomerName grade than 15 chars"), MinLength(2, ErrorMessage = "CustomerName less than 2 chars")]
        public string CustomerName { get; set; }

        [Required]
        [Range(2,10000,ErrorMessage = "numHourForProject not between 2-10000")]
        public decimal numHourForProject { get; set; }


        [Required(ErrorMessage = "DateBegin is required")]
       // []
        public DateTime DateBegin { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public DateTime DateEnd { get; set; }

        public bool IsFinish { get; set; } = false;

        public int IdManager { get; set; }
        public User Manager { get; set; }

 
    }
}

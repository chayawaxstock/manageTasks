﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Models
{
    class PresentDay
    {
        public int PresentDayId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class ClassRoom
    {
        
        public int DepartmentId { get; set; }

        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public string Day { get; set; }
        public string ToTime { get; set; }
        public string FromTime { get; set; }

    }
}
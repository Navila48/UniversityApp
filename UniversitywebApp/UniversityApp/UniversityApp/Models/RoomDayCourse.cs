using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityApp.Models
{
    public class RoomDayCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public int DayId { get; set; }
        public string Day { get; set; }
    }
}
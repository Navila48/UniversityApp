using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ResultManagementApp.Models;
using UniversityApp.GateWay;
using UniversityApp.Models;
using UniversityApp.ViewModel;

namespace UniversityApp.Manager
{
    public class ScheduleManager
    {
        ScheduleGateway aScheduleGateway=new ScheduleGateway();
        public List<Department> GetAllDepartments()
        {
            return aScheduleGateway.GetAllDepartments();
        }

        public List<RoomAllocationScheduleVM> GetAllCourseSchedules(int departmentId)
        {
          //  CourseMustafa aCourse=new CourseMustafa();
          //List<CourseMustafa> courses =aScheduleGateway.GetCourseDetails(departmentId);

            //if (courses!=null)
            //{
            //    List<RoomAllocationScheduleVM> courseList = new List<RoomAllocationScheduleVM>();
            //    foreach (var course in courses)
            //    {
                    
            //        var aRoom= aScheduleGateway.GetAllCourseSchedules(departmentId, course.Code);
            //        courseList.Add(aRoom);
            //    }
            //   return courseList;;
            //}

            //else
            //{
            //    List<RoomAllocationScheduleVM> here = null;
            //    return here;
            //}
            return aScheduleGateway.GetAllCourseSchedules(departmentId);
        }

        public string UnallocateRooms()
        {
            int rowEffected=aScheduleGateway.UnallocateRooms();
            if (rowEffected > 0)
            {
                return "Unallocated All Rooms";
            }
            return "Unallocation Failed";
        }
    }
}
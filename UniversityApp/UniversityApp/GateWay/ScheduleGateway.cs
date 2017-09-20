using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using ResultManagementApp.Models;
using UniversityApp.Models;
using UniversityApp.ViewModel;

namespace UniversityApp.GateWay
{
    public class ScheduleGateway : Gateway
    {
        //        public List<RoomAllocationScheduleVM> GetAllocatedRoomWithSchedule(int departmentId)
        //        {
        //            Query = @"select c.Code,c.Name,ac.Day,ac.ToTime,ac.FromTime,r.RoomNo
        // from Course c left outer join AllocateClassRoom ac on ac.CourseId=c.id 
        // left outer join ClassRoom r on r.id=ac.RoomId where c.DepartmentId=departmentId";


        //        }

        public List<Department> GetAllDepartments()
        {
            Query = @"SELECT d.id,d.Name FROM Department d";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (Reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = (int) Reader["id"];
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }



        public List<RoomAllocationScheduleVM> GetAllCourseSchedules(int departmentId)
        {
//            Query = @"select c.Code,c.Name,coalesce(('R.NO : '+cast(RoomNo as varchar)+', '+cast(Day as varchar)+', '+format(cast(FromTime as datetime),'hh:mm tt')+' - '+format(cast(ToTime as datetime),'hh:mm tt')+';'),'Not Scheduled') as ScheduleInfo
// from Course c left outer join AllocateClassRoom ac on ac.CourseId=c.id 
// left outer join ClassRoom r on r.id=ac.RoomId WHERE c.DepartmentId='" + departmentId + "'AND c.Code='" + code + "'";
            Query = "SELECT [Code], [Name], STUFF((SELECT ' ' + A.[ScheduleInfo] FROM Schedule A Where A.[Code]=B.[Code] FOR XML PATH('')),1,1,'') As [ScheduleInfo] From Schedule B where departmentId='" + departmentId + "' Group By [Code], [Name]";
            Connection.Open();

            Command = new SqlCommand(Query, Connection);

            Reader = Command.ExecuteReader();
            
            List<RoomAllocationScheduleVM> CourseSchedules = new List<RoomAllocationScheduleVM>();
            while (Reader.Read())
            {
                RoomAllocationScheduleVM roomAllocationSchedule = new RoomAllocationScheduleVM();
                roomAllocationSchedule.Code = Reader["Code"].ToString();
                roomAllocationSchedule.Name = Reader["Name"].ToString();
                roomAllocationSchedule.Schedule = Reader["ScheduleInfo"].ToString();
               CourseSchedules.Add(roomAllocationSchedule);

            }

            Reader.Close();
            Connection.Close();
            return CourseSchedules;

            //roomAllocationSchedule.RoomNo = Reader["RoomNo"].ToString();
            //roomAllocationSchedule.Day = Reader["Day"].ToString();
            //roomAllocationSchedule.ToTime = Reader["ToTime"].ToString();
            //roomAllocationSchedule.FromTime = Reader["FromTime"].ToString();

        }

    

public int UnallocateRooms()
        {
            Query = "update AllocateClassRoom set RoomId=null ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;

        }

public List<CourseMustafa> GetCourseDetails(int deptId)
{


    Query = "SELECT * FROM Course Where DepartmentId=@departmentId";
    Command = new SqlCommand(Query, Connection);
    Connection.Open();
    Command.Parameters.Clear();
    Command.Parameters.Add("departmentId", SqlDbType.Int);
    Command.Parameters["departmentId"].Value = deptId;
    Reader = Command.ExecuteReader();
    CourseMustafa courseMustafa = null;
    List<CourseMustafa> courseList=new List<CourseMustafa>();
    while (Reader.Read())
    {
        courseMustafa = new CourseMustafa()
        {
            
            Code = Reader["Code"].ToString(),
        };

        courseList.Add(courseMustafa);
    }
    Reader.Close();
    Connection.Close();
    return courseList;
}

    }
}
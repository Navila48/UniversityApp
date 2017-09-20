using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityApp.Models;

namespace UniversityApp.GateWay
{
    public class AllocateRoomGateway : Gateway
    {
        // CourseStatGateway aCourseStatGateway=new CourseStatGateway();

        public List<DepartmentHira> GetAllDepartments()
        {
            //return aCourseStatGateway.GetAllDepartments();
            Query = "SELECT * From Department";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<DepartmentHira> departments = new List<DepartmentHira>();
            while (Reader.Read())
            {
                DepartmentHira aDepartment = new DepartmentHira();
                aDepartment.Id = (int)Reader["id"];
                aDepartment.Name = Reader["Name"].ToString();
                departments.Add(aDepartment);

            }
            Connection.Close();
            return departments;

        }


        public List<CourseHira> GetAllCourses()
        {


            Query = "SELECT * From Course";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseHira> courses = new List<CourseHira>();
            while (Reader.Read())
            {
                CourseHira aCourseHira = new CourseHira();
                aCourseHira.Id = (int)Reader["id"];
                aCourseHira.DepartmentId = (int)Reader["DepartmentId"];
                aCourseHira.Name = Reader["Name"].ToString();
                courses.Add(aCourseHira);

            }
            Connection.Close();
            return courses;

        }


        public List<Room> GetAllRoomNo()
        {


            Query = "SELECT * From ClassRoom";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (Reader.Read())
            {
                Room aRoom = new Room();
                aRoom.Id = (int)Reader["id"];
                aRoom.RoomNo = Reader["RoomNo"].ToString();
                rooms.Add(aRoom);

            }
            Connection.Close();
            return rooms;

        }


        public List<Day> GetAllDays()
        {


            Query = "SELECT * From Day";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Day> days = new List<Day>();
            while (Reader.Read())
            {
                Day aDay = new Day();
                aDay.Id = (int)Reader["id"];
                aDay.DayName = Reader["Day"].ToString();
                days.Add(aDay);

            }
            Connection.Close();
            return days;

        }



        public int AllocateRoom(ClassRoom aClassRoom)
        {
            Query = "INSERT INTO AllocateClassRoom VALUES(@deptId,@crsId,@roomId,@day,cast(@fromTime as nvarchar(50)),cast(@toTime as nvarchar(50)))";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("deptId", SqlDbType.VarChar);
            Command.Parameters["deptId"].Value = aClassRoom.DepartmentId;
            Command.Parameters.Add("crsId", SqlDbType.VarChar);
            Command.Parameters["crsId"].Value = aClassRoom.CourseId;
            Command.Parameters.Add("roomId", SqlDbType.VarChar);
            Command.Parameters["roomId"].Value = aClassRoom.RoomId;
            Command.Parameters.Add("day", SqlDbType.VarChar);
            Command.Parameters["day"].Value = aClassRoom.Day;
            Command.Parameters.Add("toTime", SqlDbType.VarChar);
            Command.Parameters["toTime"].Value = aClassRoom.ToTime;
            Command.Parameters.Add("fromTime", SqlDbType.VarChar);
            Command.Parameters["fromTime"].Value = aClassRoom.FromTime;
            
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        //public bool IsTimeRangeValid(ClassRoom aClassRoom)
        //{
        //    Query = "SELECT FromTime, ToTime  From AllocateClassRoom where(((FromTime<=(Cast(@fromTime as nvarchar(50)) ))Or (FromTime>=(Cast(@toTime as nvarchar(50))))) And ((ToTime<=(Cast(@fromTime as nvarchar(50)) ))Or (ToTime>=(Cast(@toTime as nvarchar(50))))) And ((FromTime>=(Cast(@toTime as nvarchar(50)) ))Or (ToTime<=(Cast(@fromTime as nvarchar(50))))))";
        //    Command = new SqlCommand(Query, Connection);

        //    Command.Parameters.Clear();
        //    Command.Parameters.Add("fromTime", SqlDbType.VarChar);
        //    Command.Parameters["fromTime"].Value = aClassRoom.FromTime;
        //    Command.Parameters.Add("toTime", SqlDbType.VarChar);
        //    Command.Parameters["toTime"].Value = aClassRoom.ToTime;
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    if (Reader.HasRows)
        //    {
        //        //Reader.HasRows;
        //        Reader.Close();
        //        Connection.Close();
        //        return true;
        //    }
        //    Connection.Close();
        //    return false;
        //}

        public bool IsOverlapping(ClassRoom aClassRoom)
        {
            Query = "DECLARE @Hello time = CAST('" + aClassRoom.FromTime + "' as datetime) + CAST('00:00' AS datetime), @Hello2 time = CAST('" + aClassRoom.ToTime + "' as datetime) - CAST('00:01' AS datetime) SELECT * FROM AllocateClassRoom  WHERE RoomId='" + aClassRoom.RoomId + "' AND  Day='" + aClassRoom.Day + "' AND FromTime BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isoverlapped = false;

            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            if (isoverlapped)
            {
                return isoverlapped;
            }

            Reader.Close();
            Connection.Close();

            Query = "DECLARE @Hello time = CAST('" + aClassRoom.FromTime + "' as datetime) + CAST('00:01' AS datetime), @Hello2 time = CAST('" + aClassRoom.ToTime + "' as datetime) - CAST('00:00' AS datetime) SELECT * FROM AllocateClassRoom WHERE RoomId='" + aClassRoom.RoomId + "' AND Day='" + aClassRoom.Day + "' AND ToTime BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();


            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            Reader.Close();
            Connection.Close();

            return isoverlapped;
        }



        public bool IsAnotherOverLapping(ClassRoom aRoomInfo, ClassRoom anotherRoomInfo)
        {
            Query = "DECLARE @Hello time = CAST('" + aRoomInfo.FromTime + "' as datetime) + CAST('00:01' AS datetime), @Hello2 time = CAST('" + aRoomInfo.ToTime + "' as datetime) - CAST('00:00' AS datetime) SELECT * FROM AllocateClassRoom WHERE RoomId='" + anotherRoomInfo.RoomId + "' AND Day='" + anotherRoomInfo.Day + "' AND '" + anotherRoomInfo.ToTime + "' BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool isoverlapped = false;

            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            if (isoverlapped)
            {
                return isoverlapped;
            }

            Reader.Close();
            Connection.Close();

            Query = "DECLARE @Hello time = CAST('" + aRoomInfo.FromTime + "' as datetime) + CAST('00:00' AS datetime), @Hello2 time = CAST('" + aRoomInfo.ToTime + "' as datetime) - CAST('00:01' AS datetime) SELECT * FROM AllocateClassRoom WHERE RoomId='" + anotherRoomInfo.RoomId + "' AND Day='" + anotherRoomInfo.Day + "' AND '" + anotherRoomInfo.FromTime + "' BETWEEN @Hello AND @Hello2";

            Command = new SqlCommand(Query, Connection);


            Connection.Open();

            Reader = Command.ExecuteReader();

            if (Reader.HasRows)
            {
                isoverlapped = true;
            }

            Reader.Close();
            Connection.Close();

            return isoverlapped;
        }



        public List<ClassRoom> GetAllTimes()
        {
            List<ClassRoom> rooms = new List<ClassRoom>();

            Query = "SELECT * FROM AllocateClassRoom";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();


            while (Reader.Read())
            {
                ClassRoom aRoomInfo = new ClassRoom();

                aRoomInfo.FromTime = Reader["FromTime"].ToString();
                aRoomInfo.ToTime = Reader["ToTime"].ToString();

                rooms.Add(aRoomInfo);
            }

            Reader.Close();
            Connection.Close();

            return rooms;
        }
    }

}
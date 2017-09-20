using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using UniversityApp.GateWay;
using UniversityApp.Models;

namespace UniversityApp.Manager
{
    public class AllocateRoomManager
    {
        AllocateRoomGateway anAllocateRoomGateway =new AllocateRoomGateway();

        public List<DepartmentHira> GetAllDepartments()
        {
            return anAllocateRoomGateway.GetAllDepartments();
        }

        public List<CourseHira> GetAllCourses()
        {
            return anAllocateRoomGateway.GetAllCourses();
        }

        public List<Day> GetAllDays()
        {
            return anAllocateRoomGateway.GetAllDays();
        }

        public List<Room> GetAllRoomNo()
        {
            return anAllocateRoomGateway.GetAllRoomNo();
        }




        //public string AllocateRoom(ClassRoom aClassRoom)
        //{
        //    //DateTimeFormatInfo _DateTimeFormatInfo = new DateTimeFormatInfo();
        //    //_DateTimeFormatInfo.LongTimePattern = "HH:mm:ss";
        //    //DateTime a = Convert.ToDateTime(aClassRoom.FromTime, _DateTimeFormatInfo);
        //    if (anAllocateRoomGateway.IsOverlapping(aClassRoom))
        //    {

        //        int rowAffected = anAllocateRoomGateway.AllocateRoom(aClassRoom);

        //        if (rowAffected > 0)
        //        {
        //            return "Saved";
        //        }

        //        return "failed";
        //    }


        //    return "time";
        //    // return aClassRoom;
        //}


        public string AllocateRoom(ClassRoom aRoomInfo)
        {

            bool isOverlapping = anAllocateRoomGateway.IsOverlapping(aRoomInfo);

            if (isOverlapping)
            {
                return "Sorry, the time you selected overlaps with another course";
            }

            List<ClassRoom> rooms = new List<ClassRoom>();

            rooms = anAllocateRoomGateway.GetAllTimes();

            foreach (ClassRoom aRoom in rooms)
            {
                isOverlapping = anAllocateRoomGateway.IsAnotherOverLapping(aRoom, aRoomInfo);

                if (isOverlapping)
                {
                    return "Sorry, the time you selected overlaps with another course";
                }
            }

            int rowAffected = anAllocateRoomGateway.AllocateRoom(aRoomInfo);

            if (rowAffected > 0)
            {
                return "Room allocation successfull";
            }

            return "An error occured";
        }

    }
}
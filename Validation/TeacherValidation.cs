using MongoDB.Driver;
using StudentTest.Helper;
using StudentTest.Model;
using StudentTest.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest
{
    class TeacherValidation
    {
        public string errMsg
        {
            get;
            private set;
        }

        public delegate void ActionOnError(string errorMsg);
        private ActionOnError act;

        public TeacherValidation(ActionOnError action)
        {
            act = action;
        }

        public bool isTeacherValid(Teacher teach)
        {
            List<Teacher> teachers = Factory.GetTeachers().AsQueryable().ToList();

            if (teach.CivilNumber == null)
            {
                errMsg = "insert civil number";
                act(errMsg);
                return false;
            }
            if (!CivilNumberValidation.isCivilNumberValid(teach.CivilNumber))
            {
                errMsg = "invalid civil number";
                act(errMsg);
                return false;
            }

            if (teachers.Find(t => t.CivilNumber == teach.CivilNumber) != null)
            {
                errMsg = "User already added";
                act(errMsg);
                return false;
            }

            if (teach.Name == null || teach.Name.Length == 0)
            {
                errMsg = "username is empty";
                act(errMsg);
                return false;
            }
            if (teach.Email == null)
            {
                errMsg = "email is empty";
                act(errMsg);
                return false;
            }
            // check email
            try
            {
                MailAddress m = new MailAddress(teach.Email);
                
            }
            catch (FormatException)
            {
                errMsg = "email is invalid";
                act(errMsg);
                return false;
            }
            
            if(teach.Phone==null || teach.Phone.Contains("[a-zA-Z]+") || teach.Phone.Length!=10)
            {
                errMsg = "phone is invalid";
                act(errMsg);
                return false;
            }
            if (teach.Faculty == 0)
            {
                errMsg = "Faculty not selected";
                act(errMsg);
                return false;
            }
            
            return true;
        }
    }
}

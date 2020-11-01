using MongoDB.Driver;
using StudentTest.Helper;
using StudentTest.Model;
using StudentTest.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest
{
    public class StudentValidation
    {
        public string errMsg
        {
            get;
            private set;
        }

        public delegate void ActionOnError(string errorMsg);
        private ActionOnError act;

        public StudentValidation(ActionOnError action)
        {
            act = action;
        }

        public bool isStudentValid(Student stud)
        {
            List<Student> students = Factory.GetStudents().AsQueryable().ToList();
            if (students.Find(s => s.CivilNumber == stud.CivilNumber)!=null)
            {
                errMsg = "User already added";
                act(errMsg);
                return false;
            }

            if (stud.Name == null || stud.Name.Length==0)
            {
                errMsg = "username is empty";
                act(errMsg);
                return false;
            }

            if (!CivilNumberValidation.isCivilNumberValid(stud.CivilNumber))
            {
                errMsg = "civil number is invalid";
                act(errMsg);
                return false;
            }
            if (stud.FacNumber == null || stud.FacNumber.Length == 0)
            {
                errMsg = "Faculty number is empty";
                act(errMsg);
                return false;
            }
            if (stud.FacNumber.Length !=9)
            {
                errMsg = "Faculty number is not correct";
                act(errMsg);
                return false;
            }
            if (stud.CourseName == null)
            {
                errMsg = "Course not selected";
                act(errMsg);
                return false;
            }
            if (stud.Degree == 0)
            {
                errMsg = "Degree not selected";
                act(errMsg);
                return false;
            }

            if (stud.Faculty == 0)
            {
                errMsg = "Faculty not selected";
                act(errMsg);
                return false;
            }

            if (stud.TypeStudy == 0)
            {
                errMsg = "Type of study not selected";
                act(errMsg);
                return false;
            }

            // if the user has selected an image

            if (stud.Image != null) {
                if (stud.Image.OriginalString.EndsWith(".jpg"))
                {
                    errMsg = "selected file is not an image";
                    act(errMsg);
                    return false;
                }
            }
            
            //TODO add more validation
            return true;
        }
    }
}

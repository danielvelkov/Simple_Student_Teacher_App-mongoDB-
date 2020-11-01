using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Model
{
    public enum Faculty { FCST=1}
    public enum TypeOfStudy { REGULAR=1, ABSENT=2 }
    public enum Degree { BACHELOR=1, MASTERsDEGREE=2}

    public class Student:User
    {
        string name;
        string civilNumber;
        string facNumber;
        Faculty faculty;
        string courseName;
        TypeOfStudy typeStudy;
        Degree degree;
        int group;
        List<Subject> studySubjects;
        Uri image;

        public Student() { }

        public Student(
            string name,
            string civilNumber,
            string facNumber, 
            Faculty faculty,
            string courseName,
            TypeOfStudy typeStudy,
            Degree degree,
            int group,
            List<Subject> studySubjects,
            Uri image)
        {
            this.Name = name;
            this.CivilNumber = civilNumber;
            this.FacNumber = facNumber;
            this.Faculty = faculty;
            this.CourseName = courseName;
            this.TypeStudy = typeStudy;
            this.Degree = degree;
            this.Group = group;
            this.StudySubjects = studySubjects;
            this.Image = image;
        }

        [BsonElement("name")]
        public string Name { get => name; set => name = value; }
        [BsonElement("facNumber")]
        public string FacNumber { get => facNumber; set => facNumber = value; }
        [BsonElement("faculty")]
        public Faculty Faculty { get => faculty; set => faculty = value; }
        [BsonElement("courseName")]
        public string CourseName { get => courseName; set => courseName = value; }
        [BsonElement("typeOfStudy")]
        public TypeOfStudy TypeStudy { get => typeStudy; set => typeStudy = value; }
        [BsonElement("degree")]
        public Degree Degree { get => degree; set => degree = value; }
        [BsonElement("group")]
        public int Group { get => group; set => group = value; }
        [BsonElement("civilNumber")]
        public string CivilNumber { get => civilNumber; set => civilNumber = value; }
        [BsonElement("studySubjects")]
        public List<Subject> StudySubjects { get => studySubjects; set => studySubjects = value; }
        [BsonElement("imageUri")]
        public Uri Image { get => image; set => image = value; }

        public ObjectId Id { get; set; }

        public override string ToString()
        {
            return "Student";
        }
    }
}

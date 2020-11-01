using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Model
{
    class Teacher:User
    {
        string name;
        string civilNumber;
        string phone;
        string email;
        Faculty faculty;
        List<Subject> taughtSubjects;

        public Teacher() { }

        public Teacher(string name,
            string civilNumber,
            string phone,
            string email,
            Faculty faculty,
            List<Subject> taughtSubjects)
        {
            this.Name = name;
            this.CivilNumber = civilNumber;
            this.Phone = phone;
            this.Email = email;
            this.Faculty = faculty;
            this.TaughtSubjects = taughtSubjects;
        }
        [BsonElement("name")]
        public string Name { get => name; set => name = value; }
        [BsonElement("civilNumber")]
        public string CivilNumber { get => civilNumber; set => civilNumber = value; }
        [BsonElement("phone")]
        public string Phone { get => phone; set => phone = value; }
        [BsonElement("email")]
        public string Email { get => email; set => email = value; }
        [BsonElement("faculty")]
        public Faculty Faculty { get => faculty; set => faculty = value; }
        [BsonElement("taughtSubjects")]
        public List<Subject> TaughtSubjects { get => taughtSubjects; set => taughtSubjects = value; }
        
        public ObjectId Id { get; set; }

        public override string ToString()
        {
            return "Teacher";
        }
    }
}

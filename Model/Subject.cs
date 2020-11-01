using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Model
{
    public class Subject
    {
        string name;
        
        public Subject(string name)
        {
            this.Name = name;
        }
        [BsonElement("subjectName")]
        public string Name { get => name; set => name = value; }
        public ObjectId Id { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}

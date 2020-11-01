using MongoDB.Driver;
using StudentTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTest.Helper
{
    class Factory
    {
        public static IMongoDatabase GetDatabase()
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("TestDB");
            return db;
        }

        public static IMongoCollection<Student> GetStudents()
        {
            IMongoDatabase db = GetDatabase();
            return db.GetCollection<Student>("Students");
        }

        public static IMongoCollection<Teacher> GetTeachers()
        { 
            IMongoDatabase db = GetDatabase();
            return db.GetCollection<Teacher>("Teachers");
        }
        public static IMongoCollection<Subject> GetSubjects()
        {
            IMongoDatabase db = GetDatabase();
            return db.GetCollection<Subject>("Subjects");
        }
    }
}

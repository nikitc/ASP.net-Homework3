using System.Collections.Generic;
using System.Linq;
using Homework3.Models;

namespace Homework3.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityContext _db;

        public StudentRepository(UniversityContext context)
        {
            _db = context;
        }

        public int GetCountStudents()
        {
            return _db.Students.Count();
        }

        public Student GetById(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            return student;
        }

        public void UpdateStudent(Student student)
        {
            _db.Students.Update(student);
            _db.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }

        public void Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            _db.Students.Remove(student);
            _db.SaveChanges();
        }
    }
}

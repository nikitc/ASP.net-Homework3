using System.Collections.Generic;
using Homework3.Models;

namespace Homework3.Services
{
    public interface IStudentRepository
    {
        Student GetById(int id);
        IEnumerable<Student> GetAllStudents();
        void Create(Student student);
        void UpdateStudent(Student student);
        void DeleteById(int id);
        int GetCountStudents();
    }
}

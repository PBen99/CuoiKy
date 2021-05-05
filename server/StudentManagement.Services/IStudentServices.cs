using System.Collections.Generic;
using StudentManagement.Core.Models;
namespace StudentManagement.Services
{
    public interface IStudentServices
    {
         public List<Student> GetStudents();
         public Student GetStudent(int studentId);
         public Student AddStudent(Student student);
         public Student EditStudent(int studentId,Student student);
         public void DeleteStudent(int studentId);
    }
}
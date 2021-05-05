using System.Collections.Generic;
using System.Linq;
using StudentManagement.Core;
using StudentManagement.Core.Models;

namespace StudentManagement.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly DataContext _context;

        public StudentServices(DataContext context)
        {
            _context = context;
        }

        public Student AddStudent(Student student)
        {
            _context.Students.Add (student);
            _context.SaveChanges();
            return student;
        }

        public void DeleteStudent(int studentId)
        {
            var student =
                _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null)
            {
                return;
            }
            _context.Students.Remove (student);
            _context.SaveChanges();
        }

        public Student EditStudent(int studentId, Student student)
        {
            var editStudent =
                _context.Students.FirstOrDefault(x => x.Id == studentId);
            if (editStudent == null)
            {
                return null;
            }
            editStudent.CourseId = student.CourseId;
            editStudent.Name = student.Name;
            editStudent.ImageUrl = student.ImageUrl;
            _context.SaveChanges();
            return editStudent;
        }

        public Student GetStudent(int studentId)
        {
            return _context.Students.FirstOrDefault(x => x.Id == studentId);
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }
    }
}

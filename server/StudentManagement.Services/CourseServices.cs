using System.Collections.Generic;
using System.Linq;
using StudentManagement.Core;
using StudentManagement.Core.Models;

namespace StudentManagement.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly DataContext _context;

        public CourseServices(DataContext context)
        {
            _context = context;
        }

        public Course AddCourse(Course course)
        {
            _context.Courses.Add (course);
            _context.SaveChanges();
            return course;
        }

        public void DeleteCourse(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id == courseId);
            if (course == null)
            {
                return;
            }
            _context.Courses.Remove (course);
            _context.SaveChanges();
        }

        public Course EditCourse(int courseId, Course course)
        {
            var editCourse =
                _context.Courses.FirstOrDefault(x => x.Id == courseId);
            if (editCourse == null)
            {
                return null;
            }
            editCourse.Name = course.Name;
            _context.SaveChanges();
            return editCourse;
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourse(int courseId)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == courseId);
        }
    }
}

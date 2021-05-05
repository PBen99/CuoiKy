using System.Collections.Generic;
using StudentManagement.Core.Models;
namespace StudentManagement.Services
{
    public interface ICourseServices
    {
        public List<Course> GetCourses();
         public Course GetCourse(int id);

         public Course AddCourse(Course course);

         public Course EditCourse(int courseId, Course course);
         public void DeleteCourse(int courseId);
    }
}
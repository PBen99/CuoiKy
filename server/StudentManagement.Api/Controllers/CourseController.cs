using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Core.Models;
using StudentManagement.Services;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseServices _courseServices;

        public CourseController(ICourseServices courseServices)
        {
            _courseServices = courseServices;
        }

        [HttpGet]
        public List<Course> Get()
        {
            return _courseServices.GetCourses();
        }

        [HttpGet("courseId")]
        public Course Get([FromRoute] int courseId)
        {
            return _courseServices.GetCourse(courseId);
        }

        [HttpPost]
        public Course Post([FromBody] Course course)
        {
            return _courseServices.AddCourse(course);
        }

        [HttpPut("courseId")]
        public Course Put([FromRoute] int courseId, [FromBody] Course course)
        {
            return _courseServices.EditCourse(courseId, course);
        }

        [HttpDelete("courseId")]
        public void Delete([FromRoute] int courseId)
        {
            _courseServices.DeleteCourse (courseId);
        }
    }
}

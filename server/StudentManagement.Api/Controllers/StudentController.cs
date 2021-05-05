using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Core.Models;
using StudentManagement.Services;

namespace StudentManagement.Api.Controllers
{
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;

        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_studentService.GetStudents());
        }

        [HttpGet("{studentId}")]
        public IActionResult Get(int studentId)
        {
            var student = _studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is invalid!");
            }
            return Ok(_studentService.AddStudent(student));
        }

        [HttpPut("{studentId}")]
        public Student Put(int studentId, [FromBody] Student student)
        {
            return _studentService.EditStudent(studentId, student);
        }

        [HttpDelete("{studentId}")]
        public void Delete(int studentId)
        {
            _studentService.DeleteStudent (studentId);
        }
    }
}

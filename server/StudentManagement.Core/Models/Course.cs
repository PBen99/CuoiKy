using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Core.Models
{
    [Table("Course")]
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}

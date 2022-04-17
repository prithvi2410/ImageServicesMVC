using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ImageServiceCoreMVC.Models
{
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }
        public int CoursePrice { get; set; }

        [InverseProperty(nameof(Student.Course))]
        public virtual ICollection<Student> Students { get; set; }
    }
}

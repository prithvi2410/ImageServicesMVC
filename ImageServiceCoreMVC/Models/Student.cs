using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ImageServiceCoreMVC.Models
{
    public partial class Student
    {
        [Key]
        public int RegisterNumber { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Students")]
        public virtual Course Course { get; set; }
    }
}

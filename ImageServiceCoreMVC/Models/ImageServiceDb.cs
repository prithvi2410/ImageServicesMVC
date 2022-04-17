using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ImageServiceCoreMVC.Models
{
    [Table("ImageServiceDb")]
    public partial class ImageServiceDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public byte[] Data { get; set; }
        [Required]
        [StringLength(10)]
        public string ImageType { get; set; }
    }
}

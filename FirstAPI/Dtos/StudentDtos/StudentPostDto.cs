﻿using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos.StudentDtos
{
    public class StudentPostDto
    {
        [Required]
        [MaxLength(25)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [Range(1,100)]
        public int AvgPoint { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}

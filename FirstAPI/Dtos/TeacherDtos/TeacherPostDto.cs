using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos.TeacherDtos
{
    public class TeacherPostDto
    {
        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}

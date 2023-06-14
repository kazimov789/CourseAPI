using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos.GroupDtos
{
    public class GroupPostDto
    {
        [Required]
        [MaxLength(20)]
        public string No { get; set; }
        [Required]
        public int TeacherId { get; set; }
    }
}

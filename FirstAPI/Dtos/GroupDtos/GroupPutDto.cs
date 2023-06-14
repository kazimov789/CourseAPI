using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos.GroupDtos
{
    public class GroupPutDto
    {
        [Required]
        [MaxLength(20)]
        public string No { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string No { get; set; }
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }  
    }
}

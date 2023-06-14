using System.Collections;

namespace FirstAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Salary { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}

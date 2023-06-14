namespace FirstAPI.Dtos.TeacherDtos
{
    public class TeacherGetDto
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public List<GroupItemInTeacherDto> Groups { get; set; }

    }

    public class GroupItemInTeacherDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public List<StudentItemInGroupDto> Students { get; set; }
    }

    public class StudentItemInGroupDto
    {
        public int Id {get; set; }
        public string FullName { get; set; }
        public int AvgPoint { get; set; }
    }
}

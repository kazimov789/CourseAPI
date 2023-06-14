namespace FirstAPI.Dtos.GroupDtos
{
    public class GroupGetDto
    {
        public int Id { get; set; }
        public string No { get; set; }
        public List<StudentItemInGroupGetDto> Students { get; set; }
    }

    public class StudentItemInGroupGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }    
        public int AvgPoint { get; set; }
    }
}

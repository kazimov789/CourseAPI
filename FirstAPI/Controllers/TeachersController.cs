using FirstAPI.DAL;
using FirstAPI.Dtos.GroupDtos;
using FirstAPI.Dtos.TeacherDtos;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public TeachersController(CourseDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<List<TeacherGetAllItemDto>> GetAll()
        {
            var data = _context.Teachers.Include(x => x.Groups).Select(x => new TeacherGetAllItemDto { Id = x.Id, FullName = x.FullName, GroupCount = x.Groups.Count }).ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<TeacherGetDto> Get(int id)
        {
            var data = _context.Teachers.Include(x => x.Groups).ThenInclude(x=>x.Students).FirstOrDefault(x => x.Id == id);

            if (data == null)
                return NotFound();

            TeacherGetDto teacherDto = new TeacherGetDto
            {
                FullName = data.FullName,
                Salary = data.Salary,
                Groups = data.Groups.Select(x=> new GroupItemInTeacherDto { Id = x.Id,No = x.No,Students = x.Students.Select(y => new StudentItemInGroupDto { Id = y.Id, FullName = y.FullName,AvgPoint=y.AvgPoint }).ToList() }).ToList(),
            };

            return Ok(teacherDto);
        }

        [HttpPost("")]
        public ActionResult Create(TeacherPostDto teacherDto)
        {

            Teacher teacher = new Teacher
            {
                FullName = teacherDto.FullName,
                Salary = teacherDto.Salary
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return StatusCode(201, new { Id = teacher.Id });
        }
    }
}

using FirstAPI.DAL;
using FirstAPI.Dtos.StudentDtos;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CourseDbContext _context;

        public StudentsController(CourseDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public ActionResult<StudentGetDto> Get(int id)
        {
            var data = _context.Students.Include(x => x.Group).FirstOrDefault(x => x.Id == id);

            if(data == null)
                return NotFound();

            var studentDto = new StudentGetDto
            {
                Id = id,
                FullName = data.FullName,
                Email = data.Email,
                AvgPoint = data.AvgPoint,
                Group = new GroupInStudentGetDto
                {
                    Id = data.GroupId,
                    No = data.Group.No
                }
            };

            return Ok(studentDto);
        }

        [HttpPost("")]
        public ActionResult Create(StudentPostDto studentDto)
        {
            if(! _context.Groups.Any(x=>x.Id == studentDto.GroupId))
            {
                ModelState.AddModelError("GroupId", "Group not found");
                return BadRequest(ModelState);
            }

            if (_context.Students.Any(x => x.Email == studentDto.Email))
            {
                ModelState.AddModelError("Email", "Email is already taken");
                return BadRequest(ModelState);
            }

            Student std = new Student
            {
                FullName = studentDto.FullName,
                Email = studentDto.Email,
                AvgPoint = studentDto.AvgPoint,
                GroupId = studentDto.GroupId,
            };

            _context.Students.Add(std); 
            _context.SaveChanges();
            return StatusCode(201, new { Id = std.Id });
        }
    }
}

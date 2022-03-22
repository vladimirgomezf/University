using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.API.Models;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return BadRequest("Student Not found!");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent([FromBody] Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return Ok(_context.Student.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student request)
        {
            var dbStudent = await _context.Student.FindAsync(request.Id);
            if (dbStudent == null)
                return BadRequest("Student not found!");

            dbStudent.PhoneNumber = request.PhoneNumber;
            dbStudent.Address = request.Address;
            dbStudent.StudentNumber = request.StudentNumber;
            dbStudent.Name = request.Name;
            dbStudent.Email = request.Email;
            dbStudent.AverageMark = request.AverageMark;

            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var dbStudent = await _context.Student.FindAsync(id);
            if (dbStudent == null)
                return BadRequest("Student not found!");

            _context.Student.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }
    }
}

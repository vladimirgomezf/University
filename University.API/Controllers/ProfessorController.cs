using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.API.Models;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Professor>>> Get()
        {
            return Ok(await _context.Professor.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> Get(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return BadRequest("Address Not found!");
            }
            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<List<Professor>>> AddProfessor([FromBody] Professor professor)
        {
            _context.Professor.Add(professor);
            await _context.SaveChangesAsync();

            return Ok(_context.Professor.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Professor>>> UpdateProfessor(Professor request)
        {
            var dbProfessor = await _context.Professor.FindAsync(request.Id);
            if (dbProfessor == null)
                return BadRequest("Professor not found!");

            dbProfessor.PhoneNumber = request.PhoneNumber;
            dbProfessor.Address = request.Address;
            dbProfessor.Salary = request.Salary;
            dbProfessor.Name = request.Name;
            dbProfessor.Email = request.Email;

            await _context.SaveChangesAsync();

            return Ok(await _context.Professor.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Professor>>> DeleteProfessor(int id)
        {
            var dbProfessor = await _context.Professor.FindAsync(id);
            if (dbProfessor == null)
                return BadRequest("Professor not found!");

            _context.Professor.Remove(dbProfessor);
            await _context.SaveChangesAsync();

            return Ok(await _context.Professor.ToListAsync());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baiThiAPI.Models;

namespace baiThiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students1Controller : ControllerBase
    {
        private readonly baiThiAPIContext _context;

        public Students1Controller(baiThiAPIContext context)
        {
            _context = context;
        }

        // GET: api/Students1
        [HttpGet]
        public IEnumerable<Students> GetStudents()
        {
            return _context.Students;
        }

        // GET: api/Students1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var students = await _context.Students.FindAsync(id);

            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // PUT: api/Students1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudents([FromRoute] int id, [FromBody] Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(students).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students1
        [HttpPost]
        public async Task<IActionResult> PostStudents([FromBody] Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudents", new { id = students.StudentID }, students);
        }

        // DELETE: api/Students1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            _context.Students.Remove(students);
            await _context.SaveChangesAsync();

            return Ok(students);
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
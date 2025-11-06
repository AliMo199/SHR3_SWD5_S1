using Microsoft.AspNetCore.Mvc;
using CourseAssign.Models;
using CourseAssign.Services;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseService _service;

        public CourseController(CourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _service.Get();
            if (courses == null || !courses.Any())
                return NotFound();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _service.GetById(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpGet("byname/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var course = await _service.CourseByName(name);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] Course course)
        {
            if (course == null)
                return BadRequest();

            await _service.AddCourse(course);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id)
                return BadRequest();

            var updated = await _service.UpdateCourse(id, course);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleted = await _service.DeleteCourse(id);
            if (!deleted)
                return NotFound();

            var remaining = await _service.Get();
            return Ok(remaining);
        }
    }
}

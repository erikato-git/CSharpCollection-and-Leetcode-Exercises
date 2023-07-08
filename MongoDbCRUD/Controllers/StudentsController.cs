using Microsoft.AspNetCore.Mvc;
using MongoDbCRUD.Models;
using MongoDbCRUD.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return _studentService.Get();
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);

            if(student== null)
            {
                return NotFound();
            }

            return student;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            _studentService.Create(student);

            return CreatedAtAction(nameof(Get), new {id = student.Id}, student);   // After student has been created Get(id) is called and returns stauts-code 201
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public ActionResult<Student> Put(string id, [FromBody] Student student)
        {
            var existingStudent = _studentService.Get(id);

            if(existingStudent == null)
            {
                return NotFound(id);
            }

            _studentService.Update(id, student);

            return NoContent();     // Status-code 204
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student = _studentService.Get(id);

            if(student == null)
            {
                return NotFound($"Student with id={id} not found");
            }

            _studentService.Remove(student.Id);

            return Ok($"Student with id={id} is deleted");
        }
    }
}

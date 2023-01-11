using Microsoft.AspNetCore.Mvc;
using System.Data;
using LayerDAL.Repository;
using LayerDAL.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gpaCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _repository;
        public SubjectController(ISubjectRepository repository) 
        {
            _repository = repository;
        }

       /* db dbop = new db();
        string msg = string.Empty;*/
        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            List<Subject> ListSubject = await _repository.GetSubjects();
            return Ok(ListSubject);
          //  return Ok(await dbContext.Contacts.ToListAsync());
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubjectController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

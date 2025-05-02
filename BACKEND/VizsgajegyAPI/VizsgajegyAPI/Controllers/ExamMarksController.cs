using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VizsgajegyAPI.Data;
using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamMarksController : ControllerBase
    {
        IExamMarksRepository repo;

        public ExamMarksController(IExamMarksRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<ExamMarks> Read()
        {
            return repo.Read();
        }


       

        [HttpPost]
        public void Create([FromBody] ExamMarks exam)
        {
            repo.CreateSubject(exam);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.RemoveSubject(id);
        }

        [HttpGet("stats/{id}")]
        public IActionResult GetStats(int id)
        {

            return Ok(repo.Statistics(id));
        }

        [HttpGet("stats")]
        public IActionResult AllStatistics()
        {
            return Ok(repo.AllStatistics());
        }
    }
}

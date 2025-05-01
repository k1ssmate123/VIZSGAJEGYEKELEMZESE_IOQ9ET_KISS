using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{subjectName}")]
        public ExamMarks? GetSubject(string subjectName)
        {
            return repo.ReadByName(subjectName);
        }
        [HttpPost]
        public void Create([FromBody] ExamMarks exam)
        {
            repo.CreateSubject(exam);
        }
        [HttpDelete("{subjectName}")]
        public void Delete(string subjectName)
        {
            repo.RemoveSubject(subjectName);
        }
    }
}

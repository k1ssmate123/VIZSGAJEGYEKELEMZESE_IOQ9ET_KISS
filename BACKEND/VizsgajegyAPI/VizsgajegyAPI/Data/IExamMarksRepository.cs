using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Data
{
    public interface IExamMarksRepository
    {
    
        void CreateSubject(ExamMarks exam);
        IEnumerable<ExamMarks> Read();

        List<string> ReadAllSubject();
        ExamMarks ReadByName(string subjectName);
   
        void RemoveSubject(string subjectName);
    }
}
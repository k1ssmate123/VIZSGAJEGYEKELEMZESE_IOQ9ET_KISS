using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Data
{
    public interface IExamMarksRepository
    {
        void CreateSubject(ExamMarks exam);
        IEnumerable<ExamMarks> Read();
        ExamMarks ReadById(int id);
        void RemoveSubject(int id);
        Statistics Statistics(int id);
    }
}
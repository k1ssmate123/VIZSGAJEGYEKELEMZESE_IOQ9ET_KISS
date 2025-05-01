using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Data
{
    public interface IExamMarksRepository
    {
        void AddMarkToSubject(int mark, string subjectName);
        void CreateSubject(string subjectName, string marksList);
        IEnumerable<ExamMarks> Read();
        List<int> ReadAllMarkOfSubject(string subjectName);
        List<string> ReadAllSubject();
        ExamMarks ReadByName(string subjectName);
        void RemoveMarkFromSubject(int mark, string subjectName);
        void RemoveSubject(string subjectName);
    }
}
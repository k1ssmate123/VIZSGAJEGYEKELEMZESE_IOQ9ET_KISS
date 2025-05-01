using VizsgajegyAPI.Models;

namespace VizsgajegyAPI.Data
{
    public class ExamMarksRepository : IExamMarksRepository
    {
        ExamMarksDbContext dbController;

        public ExamMarksRepository(ExamMarksDbContext dbController)
        {
            this.dbController = dbController;
        }

        public ExamMarks ReadByName(string subjectName)
        {
            return dbController.ExamMarksList.FirstOrDefault(x => x.SubjectName == subjectName);
        }

        public void AddMarkToSubject(int mark, string subjectName)
        {
            ReadByName(subjectName).Marks.Add(mark);
        }

        public void RemoveMarkFromSubject(int mark, string subjectName)
        {
            ReadByName(subjectName).Marks.Remove(mark);
        }

        public void AddSubject(string subjectName)
        {
            dbController.ExamMarksList.Add(new ExamMarks { SubjectName = subjectName, Marks = new List<int>() });
        }

        public void RemoveSubject(string subjectName)
        {
            dbController.ExamMarksList.Remove(ReadByName(subjectName));
        }

        public List<string> ReadAllSubject()
        {
            List<string> temp = new List<string>();
            foreach (var item in dbController.ExamMarksList)
            {
                temp.Add(item.SubjectName);
            }
            return temp;
        }
        public List<int> ReadAllMarkOfSubject(string subjectName)
        {
            return ReadByName(subjectName).Marks;
        }

        public IEnumerable<ExamMarks> Read()
        {
            return dbController.ExamMarksList;
        }
    }
}

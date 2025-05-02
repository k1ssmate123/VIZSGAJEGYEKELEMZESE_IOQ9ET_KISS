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
        public IEnumerable<ExamMarks> Read()
        {
            return dbController.ExamMarksList;
        }
        public ExamMarks ReadByName(string subjectName)
        {
            return dbController.ExamMarksList.FirstOrDefault(x => x.SubjectName == subjectName);
        }

 

     

        public  void CreateSubject(string subjectName, string marksList)
        {
            ExamMarks temp = new ExamMarks(subjectName, marksList);
            dbController.ExamMarksList.Add(temp);
            dbController.SaveChanges();
        }

        public void RemoveSubject(string subjectName)
        {
            dbController.ExamMarksList.Remove(ReadByName(subjectName));
            dbController.SaveChanges();
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
     

     

  
    }
}

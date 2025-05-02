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
        public ExamMarks ReadById(int id)
        {
            return dbController.ExamMarksList.FirstOrDefault(x => x.Id == id);
        }

        public Statistics AllStatistics()
        {
            List<int> allMark = new List<int>();
        
            foreach (var item in dbController.ExamMarksList)
            {
                allMark = allMark.Concat(item.Marks).ToList();
            }
            return Statistics(allMark);
        }

        public Statistics Statistics(List<int> list)
        {
            var grades = list.OrderBy(x => x);

            var result = new Statistics();
            if (grades.Count() > 0)
            {
                var average = grades.Average();
                var median = list.Count() % 2 == 0
                    ? (list[list.Count() / 2 - 1] + list[list.Count() / 2]) / 2.0
                    : list[list.Count() / 2];

                var mode = grades
                    .GroupBy(x => x)
                    .OrderByDescending(g => g.Count())
                    .First()
                    .Key;

                var distribution = grades
                    .GroupBy(x => x)
                    .ToDictionary(g => g.Key.ToString(), g => g.Count());

                result = new Statistics
                {
                    Average = average,
                    Median = median,
                    Mode = mode,
                    Min = grades.Min(),
                    Max = grades.Max(),
                    Distribution = distribution
                };
            }
            return result;
        }
        public Statistics Statistics(int id)
        {
            var list = ReadById(id).Marks;
            return Statistics(list);
        }


        public void CreateSubject(ExamMarks exam)
        {
            dbController.ExamMarksList.Add(exam);
            dbController.SaveChanges();
        }

        public void RemoveSubject(int id)
        {
            dbController.ExamMarksList.Remove(ReadById(id));
            dbController.SaveChanges();
        }


    }
}

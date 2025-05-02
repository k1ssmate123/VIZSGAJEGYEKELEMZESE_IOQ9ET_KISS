namespace VizsgajegyAPI.Models
{
    public class Statistics
    {
        ExamMarks exam;

        public Statistics(ExamMarks exam)
        {
            this.exam = exam;
        }

        public double Avarage
        {
            get
            {
                double avg = 0;
                foreach (var item in exam.Marks)
                {
                    avg += item;
                }
                return avg / exam.Marks.Count;
            }   
        }
        public List<int> Median
        {
            get
            {

                return exam.Marks.GroupBy(x => x)
             .OrderByDescending(g => g.Count())
             .GroupBy(g => g.Count())
             .First()
             .Select(g => g.Key).ToList();



            }
        }



    }
}

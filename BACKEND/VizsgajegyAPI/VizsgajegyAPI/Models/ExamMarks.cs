using System.ComponentModel.DataAnnotations;

namespace VizsgajegyAPI.Models
{
    public class ExamMarks
    {
        [Key]
        public int Id { get; set; }
        public string? SubjectName{ get; set; }


        public List<int>? Marks { get; set; }

        public ExamMarks()
        {
            
        }

        public ExamMarks(string? subjectName, string marks)
        {
            
            SubjectName = subjectName;
            Marks = new List<int>();
            foreach (var item in marks.Split(';'))
            {
                try
                {
                    Marks.Add(int.Parse(item));
                }
                catch(Exception e)
                {
                    
                }
            }
        }
    }
}

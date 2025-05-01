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



    }
}

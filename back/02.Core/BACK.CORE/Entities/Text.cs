namespace BACK.CORE.Entities;

public class Text
{
                public int TextId { get; set; }
                public string Content { get; set; }
                public string Level { get; set; }

                // Relación con los exámenes que usan el texto
               // public ICollection<Exam> Exams { get; set; }
    

}
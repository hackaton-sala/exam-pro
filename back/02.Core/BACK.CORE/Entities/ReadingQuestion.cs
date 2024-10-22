namespace BACK.CORE.Entities;

public class ReadingQuestion
{
        public int ReadingQuestionId { get; set; }
        public string Text { get; set; }
        public string Question { get; set; }
        public string [] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        
        
    


}
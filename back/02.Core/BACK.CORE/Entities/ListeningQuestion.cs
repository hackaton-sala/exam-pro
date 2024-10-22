namespace BACK.CORE.Entities;

public class ListeningQuestion
{
        public int ListeningQuestionId { get; set; }
        public string AudioUrl { get; set; }
        public string Question { get; set; }
        public string[] Options { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
        
    


}
namespace BACK.CORE.Entities;

public class SpeakingQuestion
{
        public int SpeakingQuestionId { get; set; }
        public string Question { get; set; }
        public string TextAnswer { get; set; }
        public string AudioAnswer { get; set; }
        
        public string Feedback { get; set; }
        
    


}
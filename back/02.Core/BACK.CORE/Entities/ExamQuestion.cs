namespace BACK.CORE.Entities;

public class ExamQuestion
{
    public int QuestionId { get; set; }
    public int GramaticalExamId { get; set; }
    public string Question { get; set; }
    public string CorrectAnswer { get; set; }
    public string UserAnswer { get; set; }
    public bool? IsCorrect { get; set; }  // Se evalúa después de responder
    //public GramaticalExam GramaticalExam { get; set; }

}
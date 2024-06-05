namespace ExaminationSystem
{
    public class McqQuestion : BaseQuestion
    {
        public Answer[] answersOptions { get; set; }
        public McqQuestion(string questionHeader) : base(questionHeader)
        {
            answersOptions = new Answer[3];
        
        }
    }
}
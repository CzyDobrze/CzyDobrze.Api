namespace CzyDobrze.Api.Models
{
    public class UpdateAnswerModel
    {
        public UpdateAnswerModel(string content, bool accepted = false)
        {
            Content = content;
            Accepted = accepted;
        }
        
        public string Content { get; set; }
        public bool Accepted { get; set; }
    }
}
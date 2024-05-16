namespace FeedBack.Service.Api.Model
{
	public class Feedback
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
    }
}

using FeedBack.Service.Api.Model;
using FeedBack.Service.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedBack.Service.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedbackController : ControllerBase
	{
		private readonly FeedbackRepository _feedbackRepo;

		public FeedbackController(FeedbackRepository feedbackRepo)
        {
			_feedbackRepo = feedbackRepo;
		}
        [HttpGet]
		public ActionResult<IReadOnlyList<Feedback>> GetFeedback(int productId, int userId)
		{
			var feedbacks = _feedbackRepo.Get(productId, userId);
			if (feedbacks.Count<=0) 
				return NotFound();
			return Ok(feedbacks);
		}

		[HttpPost]
		public ActionResult<Feedback> AddFeedback(Feedback feedback)
		{
			var result = _feedbackRepo.Add(feedback);
			if (result <= 0)
				return BadRequest();
			return Ok(feedback);
		}

		[HttpPut]
		public ActionResult<Feedback> UpdateFeedback(Feedback feedback)
		{
			var result = _feedbackRepo.Update(feedback);
			if (result <= 0)
				return BadRequest();
			return Ok(feedback);
		}
		[HttpDelete]
		public ActionResult<Feedback> DeleteFeedback(int id)
		{
			var result = _feedbackRepo.Delete(id);
			if (result <= 0)
				return NotFound();
			return Ok();
		}

	}
}

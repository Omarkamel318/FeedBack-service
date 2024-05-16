using FeedBack.Service.Api.Data;
using FeedBack.Service.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace FeedBack.Service.Api.Repositories
{
	public class FeedbackRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public FeedbackRepository(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}
		public IReadOnlyList<Feedback> Get(int productId , int userId) 
			=>_dbContext.Set<Feedback>().Where(f=>f.UserId == userId&&f.ProductId==productId).ToList();

		public int Add(Feedback entity) {
			_dbContext.Set<Feedback>().Add(entity);
			return _dbContext.SaveChanges();
		}
		public int Update(Feedback entity)
		{
			_dbContext.Set<Feedback>().Update(entity);
			return _dbContext.SaveChanges();
		}
		public int Delete(int id)
		{
			var entity = _dbContext.Set<Feedback>().Where(f=>f.Id==id).FirstOrDefault();
			if (entity is not null) 
				_dbContext.Set<Feedback>().Remove(entity);

			return _dbContext.SaveChanges();
		}

		}
	}

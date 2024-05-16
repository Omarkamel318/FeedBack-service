using FeedBack.Service.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace FeedBack.Service.Api.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions dbContext) : base(dbContext)
        {
            
        }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}

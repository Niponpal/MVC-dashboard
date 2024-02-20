using Microsoft.EntityFrameworkCore;
using TMS.Models;

namespace TMS.ApplicationDbContext;

public class Teacher_DbS:DbContext
{
    public Teacher_DbS(DbContextOptions<Teacher_DbS> dbContextOptions):base(dbContextOptions)
    {
        
    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(Teacher_DbS).Assembly);
	}
}

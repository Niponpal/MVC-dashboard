using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TMS.ApplicationDbContext;
using TMS.Models;

namespace TMS.Controllers
{
	public class TeacherController : Controller
	{
		private readonly Teacher_DbS teacher_Db;
        public TeacherController(Teacher_DbS teacher_Db)
        {
			this.teacher_Db = teacher_Db;
            
        }
		[HttpGet]
		// DataBase Table Show
        public async Task<IActionResult> Index()
		{
			var data = await teacher_Db.Set<Teacher>().AsNoTracking().ToListAsync();
			return View(data);
		}
		[HttpGet]
		
		public async Task<IActionResult> CreateOrEdit(int id)
		{
            if (id==0)
            {
				return View(new Teacher());
                
            }
            else
            {
				var data = await teacher_Db.Set<Teacher>().FindAsync(id);
				return View(data);
            }
        }

		[HttpPost]
		public async Task<IActionResult> CreateOrEdit(int id, Teacher teacher)
		{
			if (id==0)
			{
                if (ModelState.IsValid)
                {
					await teacher_Db.Set<Teacher>().AddAsync(teacher);
					await teacher_Db.SaveChangesAsync();
					return RedirectToAction("Index");
                    
                }
            }
            else
            {
                teacher_Db.Set<Teacher>().Update(teacher);
				teacher_Db.SaveChanges();
				return RedirectToAction("Index");
            }
			return View(teacher);
        }
		public async Task<IActionResult> Deleted(int id)
		{
			if (id != 0)
			{
				var data = await teacher_Db.Set<Teacher>().FindAsync(id);
                if (data is not null)
                {
					teacher_Db.Set<Teacher>().Remove(data);
					await teacher_Db.SaveChangesAsync();
					
                    
                }
				
			}
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Detials(int id)
		{
			var data = await teacher_Db.Set<Teacher>().FindAsync(id);
			return View(data);

		}
	}
}

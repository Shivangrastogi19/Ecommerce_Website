using Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interface;

namespace Services.Implementation
{
	public class CategoryServices : ICategoryServices
	{
		private readonly ApplicationDbContext _context;

		public CategoryServices(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task AddCategory(Category model)
		{
			var result = await _context.Categories.AddAsync(model);
			_context.SaveChanges();
		}
	}
}

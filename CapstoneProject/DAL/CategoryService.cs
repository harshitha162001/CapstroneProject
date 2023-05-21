using CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Web.Http.Results;
using System.Web.Http;

namespace CapstoneProject.DAL
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService()
        {
            _context = new ApplicationDbContext();
        }
        public async  Task<int> AddCategoryAsync(Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@CategoryDescription", category.Description));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddCategory @CategoryName, @CategoryDescription", parameter.ToArray()));
            return result;
        }

        public  async Task<int> DeleteCategoryAsync(int Id)
        {
            var parameter = new SqlParameter("@CategoryId", Id);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteCategory @CategoryId", parameter));
            return result;
        }

        public  async Task<IEnumerable<Category>> GetCategoryByIdAsync(int Id)
        {
            var parameter = new SqlParameter("@CategoryId", Id);

            var result = await Task.Run(() => _context.Categories
            .FromSqlRaw(@"exec GetCategoryById @CategoryId", parameter).ToListAsync());
            return result;
        }

        public async  Task<List<Category>> GetCategoryListAsync()
        {
            return await _context.Categories
                 .FromSqlRaw<Category>("GetListOfCategoryMedicines")
                 .ToListAsync();
        }

        public async  Task<int> UpdateCategoryAsync(int Id, Category category)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("CategoryId", Id));
            parameter.Add(new SqlParameter("@CategoryName", category.CategoryName));
            parameter.Add(new SqlParameter("@CategoryDescription", category.Description));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec EditCategory @CategoryId, @CategoryName, @CategoryDescription", parameter.ToArray()));
            return result;
        }
    }
}

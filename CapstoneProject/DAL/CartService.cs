using CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Web.Http.Results;
using System.Web.Http;
using System.Data.Common;

namespace CapstoneProject.DAL
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;
        public CartService()
        {
            _context = new ApplicationDbContext();
        }
        public  async Task<int> AddCartAsync(Cart cart)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Name", cart.Name));
            parameter.Add(new SqlParameter("@Price", cart.Price));
            parameter.Add(new SqlParameter("@Seller", cart.Seller));
            parameter.Add(new SqlParameter("@Status", cart.Status));
            parameter.Add(new SqlParameter("@UserId", cart.UserId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddCarts @Name, @Price, @Seller, @Status, @UserId", parameter.ToArray()));
            return result;
        }

       

        public async Task<int> EmptyCartAsync()
        {
            var result = await Task.Run(() => _context.Database
           .ExecuteSqlRawAsync(@"exec EmptyCart"));
            return result;
        }
        public async Task<int> DeleteCartAsync(int Id)
        {
            var parameter = new SqlParameter("@CartId", Id);

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteCarts @CartId", parameter));
            return result;
        }

        public async  Task<IEnumerable<Cart>> GetCartByIdAsync(int Id)
        {
            var parameter = new SqlParameter("@CartId", Id);

            var result = await Task.Run(() => _context.Carts
            .FromSqlRaw(@"exec GetCartById @CartId", parameter).ToListAsync());
            return result;
        }

        public async  Task<IEnumerable<Cart>> GetCartByUserIdAsync(int Id)
        {
            var parameter = new SqlParameter("@UserId", Id);

            var result = await Task.Run(() => _context.Carts
            .FromSqlRaw(@"exec GetCartByUserId @UserId", parameter).ToListAsync());
            return result;
        }

        public  async Task<List<Cart>> GetCartListAsync()
        {
            return await _context.Carts
              .FromSqlRaw<Cart>("GetCartsList")
              .ToListAsync();
        }
    }
}

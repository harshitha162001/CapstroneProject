using CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Web.Http.Results;
using System.Web.Http;

namespace CapstoneProject.DAL
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService()
        {
            _context = new ApplicationDbContext();
        }
        public  async Task<int> AddUserAsync(User user)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@UserName", user.Name));
            
            param.Add(new SqlParameter("@UserPass", user.Password));
            param.Add(new SqlParameter("@UserEmail", user.Email));
            param.Add(new SqlParameter("@UserType", user.Type));
            param.Add(new SqlParameter("@UserDate", user.CreatedOn));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddUser @UserName, @UserPass, @UserEmail, @UserType, @UserDate", param.ToArray()));
            return result;
        }

        public async  Task<int> DeleteUserAsync(int Id)
        {
            var param = new SqlParameter("@UserId", Id);
            var details = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec DeleteUser @UserId", param));
            return details;
        }

        public  async Task<IEnumerable<User>> GetUserByIdAsync(int Id)
        {
            /* var param = new SqlParameter("@UserId", Id);
            var userDetails = await Task.Run(() => _context.Userss
            .FromSqlRaw(@"exec GetUserById @UserId", param).ToListAsync());
            return userDetails;*/
            var param = new SqlParameter("@UserId", Id);
            var userDetails = await Task.Run(() => _context.Users
            .FromSqlRaw(@"exec GetUserById @UserId", param).ToListAsync());
            return userDetails;
        }

        public  async Task<List<User>> GetUsersListAsync()
        {
            return await _context.Users
                .FromSqlRaw<User>("GetUsersList")
                .ToListAsync();

        }

        public async  Task<IEnumerable<User>> Login(string email, string password)
        {
            var param = new SqlParameter("@UserEmail", email);
            var param1 = new SqlParameter("@UserPassword", password);

            var loginDetails = await Task.Run(() => _context.Users
            .FromSqlRaw(@"exec Login @UserEmail, @UserPassword", param, param1).ToListAsync());
            return loginDetails;

        }
    }
}

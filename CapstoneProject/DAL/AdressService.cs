using  CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Web.Http.Results;
using System.Web.Http;
using System.Data.Common;

namespace CapstoneProject.DAL
{
    public class AdressService:IAdressService
    {
        private readonly ApplicationDbContext _context;
        public AdressService()
        {
            _context = new ApplicationDbContext();
        }

        public  async Task<int> AddAdressAsync(Adress address)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UserName", address.UserName));
            parameter.Add(new SqlParameter("@Email", address.Email));
            parameter.Add(new SqlParameter("@Phone", address.Phone));
            parameter.Add(new SqlParameter("@Location", address.Location));
            parameter.Add(new SqlParameter("@Country", address.Country));
            parameter.Add(new SqlParameter("@State", address.State));
            parameter.Add(new SqlParameter("@UserId", address.UserId));

            var result = await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddAdress @UserName, @Email, @Phone, @Location, @Country, @State,@UserId", parameter.ToArray()));
            return result;
        }

        public  async Task<IEnumerable<Adress>> GetAdressByUserIdAsync(int Id)
        {
            var parameter = new SqlParameter("@UserId", Id);

            var result = await Task.Run(() => _context.Adresses
            .FromSqlRaw(@"exec GetAdressByUserId @UserId", parameter).ToListAsync());
            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using CapstoneProject.Models;
namespace CapstoneProject.DAL
{
    public interface IAdressService
    {
        public Task<IEnumerable<Adress>> GetAdressByUserIdAsync(int Id);
        public Task<int> AddAdressAsync(Adress address);
    }
}

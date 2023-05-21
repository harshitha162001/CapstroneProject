using CapstoneProject.DAL;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Net;

namespace CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IAdressService addressService;
        public AdressController(IAdressService addressService)
        {
            this.addressService = addressService;
        }
        [HttpGet]
        [Route("GetAdressByUserId")]
        public async Task<IEnumerable<Adress>> GetCartByAdressIdAsync(int Id)
        {
            try
            {
                var response = await addressService.GetAdressByUserIdAsync(Id);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("AddAdress")]
        public async Task<IActionResult> AddAdress(Adress address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await addressService.AddAdressAsync(address);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}

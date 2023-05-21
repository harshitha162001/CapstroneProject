using CapstoneProject.DAL;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet]
        [Route("GetCartsList")]
        public async Task<List<Cart>> GetCartAsync()
        {
            try
            {
                return await cartService.GetCartListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetCartById")]
        public async Task<IEnumerable<Cart>> GetCartByIdAsync(int Id)
        {
            try
            {
                var response = await cartService.GetCartByIdAsync(Id);
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
        [HttpGet]
        [Route("GetCartByUserId")]
        public async Task<IEnumerable<Cart>> GetCartByUserIdAsync(int Id)
        {
            try
            {
                var response = await cartService.GetCartByUserIdAsync(Id);
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
        [HttpDelete]
        [Route("DeleteCarts")]
        public async Task<IActionResult> DeleteCart(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await cartService.DeleteCartAsync(Id);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("EmptyCart")]
        public async Task<IActionResult> EmptyCart()
        {
            try
            {
                var response = await cartService.EmptyCartAsync();
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        [HttpPut]
        [Route("AddCarts")]
        public async Task<IActionResult> AddCart(Cart cart)
        {
            if (cart == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await cartService.AddCartAsync(cart);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poc.Web.DAL;
using Poc.Web.Entities;

namespace Poc.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        AmazonDbContext db = new AmazonDbContext();
        myCart c = new myCart();

        [HttpPost("getCart")]
        public IEnumerable<Cart> Get([FromBody] Cart model)
        {
            var result = c.GetCartValue(model);
            return result;
        }


        [HttpGet("getCarts/{userId}")]
        public async Task<ActionResult<IEnumerable<Cart>>> Get(int userId)
        {
            return await db.Carts.Where(c => c.CustomerId == userId).ToListAsync();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cart model)
        {
            var result = c.AddCart(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return c.RemoveFromCart(id);
        }

    }
}
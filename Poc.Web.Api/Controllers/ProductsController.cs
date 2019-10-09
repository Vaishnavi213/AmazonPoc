using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poc.Web.DAL;
using Poc.Web.Entities;

namespace Poc.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(AmazonDbContext context)
        {

        }

        ProductLogic productObj = new ProductLogic();

        // Get : api/Product
        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                var pro = productObj.getData();
                return Ok(pro);
            }
            else
            {
                return BadRequest("Not a Valid Model");
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                if (productObj.datavalid(id))
                {
                    var pro = productObj.getDataById(id);
                    return Ok(pro);
                }
                else
                {
                    return BadRequest("Not a valid ID");
                }
            }
            else
            {
                return BadRequest("Not a valid Model");
            }
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                if (productObj.addProduct(model) == true)
                    return Ok();
                else
                    return NotFound();
            }
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product model)
        {
            if (ModelState.IsValid)
            {
                if (productObj.updateData(id, model) == true)
                {
                    return Ok("Data Updated");
                }
                else
                {
                    return BadRequest("Invalid Id");
                }
            }
            else
            {
                return BadRequest("Model is not valid");
            }
        }

        // DELETE: api/Product/5   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (productObj.deleteData(id))
                {
                    return Ok("Record deleted");
                }
                else
                {
                    return BadRequest("Invalid Id");
                }
            }
            else
            {
                return BadRequest("Invalid Model");
            }
        }
    }
}
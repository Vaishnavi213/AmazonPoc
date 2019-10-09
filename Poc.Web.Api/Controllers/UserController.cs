//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Poc.Web.DAL;
//using Poc.Web.Entities;

//namespace Poc.Web.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        public UserController(PocDbContext context)
//        {
                
//        }

//        user userObj = new user();

//        // Get : api/Customer
//        [HttpGet]
//        public IActionResult Get()
//        {
//            if (ModelState.IsValid)
//            {
//                var _user = userObj.getData();
//                return Ok(_user);
//            }
//            else
//            {
//                return BadRequest("Not a Valid Model");
//            }
//        }

//        // GET: api/Customer/5
//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            if (ModelState.IsValid)
//            {
//                if (userObj.datavalid(id))
//                {
//                    var _user = userObj.getDataById(id);
//                    return Ok(_user);
//                }
//                else
//                {
//                    return BadRequest("Not a valid ID");
//                }
//            }
//            else
//            {
//                return BadRequest("Not a valid Model");
//            }
//        }

//        // POST: api/Customer
//        [HttpPost]
//        public IActionResult Post([FromBody] Customer model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest("Invalid Data");
//            }
//            else
//            {
//                if (userObj.addProduct(model) == true)
//                    return Ok();
//                else
//                    return NotFound();
//            }
//        }

//        // PUT: api/Customer/5
//        [HttpPut("{id}")]
//        public IActionResult Put(int id, [FromBody] Customer model)
//        {
//            if (ModelState.IsValid)
//            {
//                if (userObj.updateData(id, model) == true)
//                {
//                    return Ok("Data Updated");
//                }
//                else
//                {
//                    return BadRequest("Invalid Id");
//                }
//            }
//            else
//            {
//                return BadRequest("Model is not valid");
//            }
//        }

//        // DELETE: api/Customer/5   
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            if (ModelState.IsValid)
//            {
//                if (userObj.deleteData(id))
//                {
//                    return Ok("Record deleted");
//                }
//                else
//                {
//                    return BadRequest("Invalid Id");
//                }
//            }
//            else
//            {
//                return BadRequest("Invalid Model");
//            }
//        }
//    }
//}
    

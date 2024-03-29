﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poc.Web.DAL;
using Poc.Web.Entities;

namespace Poc.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public RegisterController(AmazonDbContext context)
        {

        }

        Register r = new Register();

        // GET: api/Register
        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid)
            {
                var u = r.getdata();
                return Ok(u);
            }
            else
            {
                return BadRequest("Not a valid model");
            }
        }

        // GET: api/Register/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (ModelState.IsValid)
            {
                if (r.datavalid(id))
                {
                    var u = r.getdatabyid(id);
                    return Ok(u);
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

        // POST: api/Register
        [HttpPost]
        public IActionResult Post([FromBody] Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                if (r.AddData(model) == true)
                    return Ok();
                else
                    return NotFound();
            }
        }

        // PUT: api/Register/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
                if (r.updateData(id, model) == true)
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


        // DELETE: api/ApiWithActions/5   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                if (r.deleteData(id))
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
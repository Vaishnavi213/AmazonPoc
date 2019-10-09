using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Poc.Web.DAL;
using Poc.Web.Entities;

namespace Poc.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login1Controller : ControllerBase
    {
        private readonly AmazonDbContext  _context;
        public Login1Controller(AmazonDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult PostD([FromBody] Customer model)
        {
            Poc.Web.DAL.Login login = new Poc.Web.DAL.Login();
            //if (ModelState.IsValid)
            //{
            if (login.login(model) == 1)
            {
                Customer customer = _context.Customers.Where(x=>x.CustEmail==model.CustEmail).Single();
                var ID = customer.CustId;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                 {
                        new Claim("Id",customer.CustId.ToString()),
                        new Claim(ClaimTypes.Role,customer.Role)
                 }),
                    Expires = DateTime.UtcNow.AddMinutes(120),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token, ID , customer.Role , customer.CustName });
            }
            else
            {
                return BadRequest("UserName Is invalid");

            }
        }
    }
}

    

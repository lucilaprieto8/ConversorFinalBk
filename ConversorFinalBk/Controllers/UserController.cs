using ConversorFinal_BE.Data;
using ConversorFinal_BE.Entities;
using ConversorFinalBk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class UserController : ControllerBase

        
    {
        private readonly ConversorContext _conversorContext;

        public UserController(ConversorContext conversorContext)
        {
            conversorContext = _conversorContext;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto userForCreation)
        {
            User user = new User()
            {
                Id = 1,
                UserName = userForCreation.UserName,
                Password = userForCreation.Password,
                IdSubscription = userForCreation.IdSubscription,
                conversions = 1
            };
            _conversorContext.Add(user);
            _conversorContext.SaveChanges();
            return Ok();
        }
    }
}

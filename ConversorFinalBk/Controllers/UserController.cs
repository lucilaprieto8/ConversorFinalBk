using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody]UserForCreationDto userForCreation)
        {
            _userService.CreateUser(userForCreation);
            return Created("Created", userForCreation);
        }
    }
}

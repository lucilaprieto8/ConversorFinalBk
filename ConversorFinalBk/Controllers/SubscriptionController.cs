using ConversorFinalBk.Models;
using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateSubscription(int id)
        {
            try
            {
                _subscriptionService.UpdateSubscription(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AllSubs")]
        public IActionResult GetAllSubscriptions()
        {
           
            return Ok(_subscriptionService.GetAllSubscription());
        }
           
        [HttpGet("getsub")]
        public IActionResult GetSubscription() 
        { 
            return Ok(_subscriptionService.GetSubscription());
        
        }
    }
}

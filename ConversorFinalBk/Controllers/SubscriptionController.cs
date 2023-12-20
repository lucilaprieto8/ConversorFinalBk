using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;
        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubscription(int id)
        {
            try
            {
                _subscriptionService.UpdateSubscription(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AllSubs")]
        public IActionResult GetAllSubscriptions()
        {
            try
            {
                return Ok(_subscriptionService.GetAllSubscription());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
           
        [HttpGet("GetSub")]
        public IActionResult GetSubscription() 
        { 
            try
            {
                return Ok(_subscriptionService.GetSubscription());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

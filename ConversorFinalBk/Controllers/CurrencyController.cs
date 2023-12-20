using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPost]
        public IActionResult CreateCurrency([FromBody] CurrencyForCreationAndUpdate currency)
        {
            try
            {
                _currencyService.CreateCurrency(currency);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCurrency(CurrencyForCreationAndUpdate currency, int id)
        {
            try
            {
                _currencyService.UpdateCurrency(currency, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCurrency(int Id)
        {
            try
            {
                _currencyService.DeleteCurrency(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public ActionResult<Currency> GetAll()
        {
            try
            {
                return Ok(_currencyService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAttemps")]
        public IActionResult GetAttemps()
        {
            try
            {
                return Ok(_currencyService.GetAttemps());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOneById(int id)
        {
            try
            {
                CurrencyDto currency = _currencyService.GetOneById(id);
                    return Ok(currency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Convert")]
        public IActionResult ConvertCurrency([FromBody]CurrencyToConvertDto currencyToConvert)
        {
            try
            { 
                var conversion = _currencyService.ConvertCurrency(currencyToConvert);
                return Ok(conversion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

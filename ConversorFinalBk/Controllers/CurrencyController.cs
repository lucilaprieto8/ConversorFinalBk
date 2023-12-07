using ConversorFinalBk.Data.Interfaces;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;
        private readonly IRepository<Currency> _repository;
        private readonly SessionService _sessionService;
        public CurrencyController(CurrencyService currencyService, IRepository<Currency> repository, SessionService sessionService)
        {
            _currencyService = currencyService;
            _repository = repository;
            _sessionService = sessionService;
        }


        [HttpPost]
        public IActionResult CreateCurrency([FromBody]CurrencyForCreation currency)
        {
            try
            {
                _currencyService.CreateCurrency(currency);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]

        public IActionResult UpdateCurrency([FromBody]CurrencyForCreation currency)
        {
            try
            {
                _currencyService.UpdateCurrency(currency);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteCurrency([FromQuery]int Id)
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
            return Ok(_currencyService.GetAll());
        }

        [HttpGet]
        [Route("GetOne")]
        public IActionResult getOneById(int id)
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
        public IActionResult ConvertCurrency(CurrencyToConvertDto currencyToConvert)
        {
     
            return Ok(_currencyService.ConvertCurrency(currencyToConvert));
        }
    }
}

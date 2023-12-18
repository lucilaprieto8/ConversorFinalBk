using ConversorFinalBk.Data.Interfaces;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ConversionService _conversionService;
        private readonly HistoryService _historyService;

        public CurrencyController(CurrencyService currencyService, IRepository<Currency> repository, SessionService sessionService, ConversionService conversionService, HistoryService historyService)
        {
            _currencyService = currencyService;
            _repository = repository;
            _sessionService = sessionService;
            _conversionService = conversionService;
            _historyService = historyService;
        }


        [HttpPost]
        public IActionResult CreateCurrency([FromBody] CurrencyForCreation currency)
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


        [HttpPut("{id}")]

        public IActionResult UpdateCurrency( CurrencyForCreation currency, int id)
        {
            try
            {
                _currencyService.UpdateCurrency(currency, id);
                return Ok("ando");
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
            return Ok(_currencyService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
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
        public IActionResult ConvertCurrency([FromBody]CurrencyToConvertDto currencyToConvert)
        
        {
            try
            { 
                _conversionService.IncrementCounter();
                return Ok(_currencyService.ConvertCurrency(currencyToConvert));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

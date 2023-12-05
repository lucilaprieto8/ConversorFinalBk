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

        public IActionResult CreateCurrency(CurrencyToCreate currencytocreate)
        {
            Currency currency = new Currency()
            {
                Leyend = currencytocreate.Leyend,
                IC = currencytocreate.IC,
                Symbol = currencytocreate.Symbol
            };
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

        public IActionResult UpdateCurrency([FromBody]Currency currency)
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

        [HttpGet]
        public ActionResult<Currency> GetAll()
        {
            return Ok(_currencyService.GetAll());
        }

        [HttpGet]
        [Route("CurrencyId")]
        public IActionResult getOneById(int getoneid)
        {
            try
            {
                Currency currency = _currencyService.GetOneById(getoneid);
                    return Ok(currency);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

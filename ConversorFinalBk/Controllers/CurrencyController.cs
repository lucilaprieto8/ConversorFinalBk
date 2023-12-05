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

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        [HttpPost]

        public IActionResult CreateCurrency([FromBody] CurrencyForCreationDto currencyForCreation)
        {
            try
            {
                _currencyService.CreateCurrency(currencyForCreation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", currencyForCreation);
        }

        [HttpPut("{Id}")]

        public IActionResult UpdateCurrency(CurrencyForCreationDto currencyForCreation, int Id)
        {
           if (!_currencyService.CheckIfCurrencyExists(Id))
            {
                return NotFound();
            }
            try
            {
                _currencyService.UpdateCurrency(currencyForCreation, Id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(currencyForCreation);
        }

        [HttpDelete]
        public IActionResult DeleteCurrency(int Id)
        {
            try
            {
                _currencyService.DeleteCurrency(Id);
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<Currency> GetAll()
        {
            return Ok(_currencyService.GetAll());
        }

        [HttpGet]
        [Route("CurrencyId")]
        public IActionResult getOneById(int id)
        {
            if (!_currencyService.CheckIfCurrencyExists(id))
            {
                return NotFound();
            }
            else
                return Ok(_currencyService.GetOneById(id));
        }
    }
}

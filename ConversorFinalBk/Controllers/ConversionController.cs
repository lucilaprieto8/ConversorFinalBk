using ConversorFinalBk.Models;
using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly ConversionService _conversionService;

        public ConversionController(ConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpGet]

        public IActionResult GetConvertionResult(CurrencyToConvertDto currencyToConvertDto)
        {
            return Ok(currencyToConvertDto);
        }
    }
}

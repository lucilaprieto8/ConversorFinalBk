using ConversorFinalBk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly HistoryService _historyService;

        public HistoryController(HistoryService historyService)
        {
            _historyService = historyService;        }

        [HttpGet]
        public IActionResult GetHistorical(int id)
        {
            _historyService.GetHistorical(id);
            return Ok();
        }
    }
}

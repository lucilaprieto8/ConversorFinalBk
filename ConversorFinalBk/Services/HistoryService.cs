using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;

namespace ConversorFinalBk.Services
{
    public class HistoryService
    {
        private readonly ConversorContext _conversorContext;
        private readonly SessionService _sessionService;
        public HistoryService(ConversorContext conversorContext, SessionService sessionService)
        {
            _conversorContext = conversorContext;
            _sessionService = sessionService;
        }
        public List<ConversionHistory> GetHistory()
        {
            var userId = _sessionService.GetUserId();
            var historial = _conversorContext.ConversionHistory.Where(u => u.IdUser == userId).ToList();

            if (historial == null)
            {
                throw new Exception("Este usuario no tiene historial");
            }
            return historial;
        }
    }
}

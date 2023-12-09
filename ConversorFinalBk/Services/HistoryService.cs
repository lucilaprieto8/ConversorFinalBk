using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Services
{
    public class HistoryService
    {
        private readonly ConversorContext _conversorContext;

        public HistoryService(ConversorContext conversorContext)
        {
            _conversorContext = conversorContext;
        }

        public ConversionHistory GetHistorical(int id)
        {
            return null;
        }
    }
}

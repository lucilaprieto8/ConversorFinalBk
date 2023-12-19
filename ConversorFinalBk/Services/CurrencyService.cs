using ConversorFinal_BE.Data;
using ConversorFinalBk.Data.Interfaces;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ConversorFinalBk.Services
{
    public class CurrencyService
    {
        private readonly ConversorContext _conversorContext;
        private readonly SessionService _sessionService;
        private readonly ConversionService _conversionService;
        private readonly HistoryService _historyService;

        public CurrencyService(ConversorContext conversorContext, SessionService sessionService, ConversionService conversionService, HistoryService historyService)
        {
            _conversorContext = conversorContext;
            _sessionService = sessionService;
            _conversionService = conversionService;
            _historyService = historyService;
        }
       public void CreateCurrency(CurrencyForCreation dto)
        {
            Currency currency = new Currency()
            {
                Id = 0,
                Leyend = dto.Leyend,
                Symbol = dto.Symbol,
                IC = dto.IC
            };
            _conversorContext.Add(currency);
            _conversorContext.SaveChanges();
        }
          
       public void UpdateCurrency(CurrencyForCreation dto, int id)
        {
             Currency? currency = _conversorContext.Currency.SingleOrDefault(c => c.Id == id);
 
            if (currency is null) 
            { 
                throw new Exception("No existe la moneda");
            }
            
            currency.IC = dto.IC;
            currency.Symbol = dto.Symbol;
            currency.Leyend = dto.Leyend;

            _conversorContext.SaveChanges();
        }


       public void DeleteCurrency(int Id)
        {
            var currencyToDelete = _conversorContext.Currency.Single(c => c.Id == Id);
            if (currencyToDelete is null)
            { 
                throw new Exception("No existe la moneda");
            }
            _conversorContext.Currency.Remove(currencyToDelete);
            _conversorContext.SaveChanges();
        }

        public List<Currency> GetAll()
        {
            return _conversorContext.Currency.ToList();
        }

        public CurrencyDto GetOneById(int Id)
        {
            var currency = _conversorContext.Currency.FirstOrDefault(c => c.Id == Id);

            if(currency is null)
            {
                throw new Exception("No existe la moneda");
            }
            return new CurrencyDto
            {
                Id = currency.Id,
                IC = currency.IC,
                Symbol = currency.Symbol,
                Leyend = currency.Leyend,
            };
        }
        public int GetAttemps()
        {
            var userId = _sessionService.GetUserId();
            var user = _conversorContext.User.FirstOrDefault(c => c.Id == userId);
            var subs = _conversorContext.Subscription.FirstOrDefault(c => c.Id == user.IdSubscription);
            var attempRegister = _conversorContext.Conversion.FirstOrDefault(u=> u.IdUser == userId);
            var attemps = subs.MaxAttemps - attempRegister.Attemps ;
            return attemps;
        }



        public double ConvertCurrency (CurrencyToConvertDto dto)
        {
            var userId = _sessionService.GetUserId();

            Conversion conversion = new Conversion()
            {
                Id = 0,
                Attemps = 0,
                FirstTry = DateTime.Now,
                IdUser = userId,
                
            };

            _conversorContext.Add(conversion);
            _conversorContext.SaveChanges();

            _conversionService.IncrementCounter();
            var currencyTo = _conversorContext.Currency.FirstOrDefault(c => c.Id == dto.CurrencyToId);
            var currencyFrom = _conversorContext.Currency.FirstOrDefault(c => c.Id == dto.CurrencyFromId);
            var result = (dto.amount * currencyFrom.IC) / currencyTo.IC;

            ConversionHistory historical = new()
            {
                Id = 0,
                ConversionDate = conversion.FirstTry,
                CurrencyFrom = currencyFrom.Leyend,
                CurrencyTo = currencyTo.Leyend,
                AmountInput = dto.amount,
                AmountOutput = result,
                IdUser = userId,
            };
            _conversorContext.Add(historical);
            _conversorContext.SaveChanges();
            return result;
        }
    }
}

using ConversorFinal_BE.Data;
using ConversorFinalBk.Data.Interfaces;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ConversorFinalBk.Services
{
    public class CurrencyService
    {
        private readonly ConversorContext _conversorContext;
        private readonly SessionService _sessionService;

        public CurrencyService(ConversorContext conversorContext, SessionService sessionService)
        {
            _conversorContext = conversorContext;
            _sessionService = sessionService;
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
          


       public void UpdateCurrency(CurrencyForCreation dto)
        {
            var currency = _conversorContext.Currency.SingleOrDefault(c => c.Id == dto.Id);
 
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
    }
}

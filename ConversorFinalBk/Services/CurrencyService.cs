using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Services
{
    public class CurrencyService
    {
        private readonly ConversorContext _conversorContext;

        public CurrencyService(ConversorContext conversorContext)
        {
            _conversorContext = conversorContext;
        }

        public void CreateCurrency(CurrencyForCreationDto currencyForCreation)
        {
            Currency currency = new Currency()
            {
                Id = 0,
                Leyend = currencyForCreation.Leyend,
                Symbol = currencyForCreation.Symbol,
                IC = currencyForCreation.IC
            };
            _conversorContext.Add(currency);
            _conversorContext.SaveChanges();
        }

        public void UpdateCurrency(CurrencyForCreationDto currencyForCreation, int Id)
        {
            var currency = _conversorContext.Currency.FirstOrDefault(c => c.Id == Id);
            currency.Leyend = currencyForCreation.Leyend;
            currency.Symbol = currencyForCreation.Symbol;
            currency.IC = currencyForCreation.IC;
            _conversorContext.SaveChanges();
        }

        public bool CheckIfCurrencyExists(int Id)
        {
            var currency = _conversorContext.Currency.FirstOrDefault(c => c.Id == Id);
            return currency != null;
        }

        public void DeleteCurrency(int Id)
        {
            _conversorContext.Currency.Remove(_conversorContext.Currency.Single(c => c.Id == Id));
            _conversorContext.SaveChanges();
        }

        public List <Currency> GetAll()
        {
            return _conversorContext.Currency.ToList();
        }
    }
}

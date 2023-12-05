using ConversorFinal_BE.Data;
using ConversorFinalBk.Data.Interfaces;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Services
{
    public class CurrencyService
    {
        private readonly IRepository<Currency> _currencyRepository;
        private readonly SessionService _sessionService;

        public CurrencyService(IRepository<Currency> Currencyrepository, SessionService sessionService)
        {
            _currencyRepository = Currencyrepository;
            _sessionService = sessionService;
        }

        public bool CreateCurrency(Currency CurrencyToCreate)
        {
            return _currencyRepository.Insert(CurrencyToCreate);
        }
        

        public bool UpdateCurrency(Currency CurrencyToUpdate, int Id)
        {
            if (!CheckIfCurrencyExists(CurrencyToUpdate.Id))
            {
                throw new Exception("No existe la moneda");
            }
            return _currencyRepository.Update(CurrencyToUpdate);
        }
        public bool CheckIfCurrencyExists(int Id)
        {
            return _currencyRepository.Exist(Id);
        }

        public bool DeleteCurrency(int Id)
        {
            return _currencyRepository.Delete(Id);
        }

        public List <Currency> GetAll()
        {
            return _currencyRepository.GetAll().ToList();
        }

        public Currency GetOneById(int Id)
        {
            return _currencyRepository.GetById(Id);
        }
    }
}

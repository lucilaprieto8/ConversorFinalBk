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
        public bool CreateCurrency(Currency currencyToCreate)
        {
            return _currencyRepository.Insert(currencyToCreate);
        }


        public bool UpdateCurrency(Currency currencyToUpdate)
        {
            if (!CheckIfCurrencyExists(currencyToUpdate.Id))
                throw new Exception("No existe la moneda");
            return _currencyRepository.Update(currencyToUpdate);
        }


        public bool CheckIfCurrencyExists(int currencyId)
        {
            return _currencyRepository.Exist(currencyId);
        }

        public bool DeleteCurrency(int deleteId)
        {
            if (!CheckIfCurrencyExists(deleteId))
                throw new Exception("No existe la moneda");
            return _currencyRepository.Delete(deleteId);
        }

        public List <Currency> GetAll()
        {
            return _currencyRepository.GetAll().ToList();
        }

        public Currency GetOneById(int getId)
        {
            if (!CheckIfCurrencyExists(getId))
                throw new Exception("No existe la moneda");
            return _currencyRepository.GetById(getId);
        }
    }
}

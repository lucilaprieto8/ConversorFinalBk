using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConversorFinalBk.Services
{
    public class UserService
    {
        private readonly ConversorContext _conversorContext;

        public UserService(ConversorContext conversorContext)
        {
            _conversorContext = conversorContext;
        }

        public void CreateUser(UserForCreationDto userForCreation)
        {
            List<ConversionHistory> conversionHistories = new List<ConversionHistory>();
            User user = new User()
            {
                Id = 0,
                UserName = userForCreation.UserName,
                Password = userForCreation.Password,
                IdSubscription = userForCreation.IdSubscription,
                ConversionHistory = conversionHistories
            };
            _conversorContext.Add(user);
            _conversorContext.SaveChanges();
        }
        public User? Validate(string user, string password)
        {
             return _conversorContext.User.SingleOrDefault(x => x.UserName == user && x.Password == password);
        }

    }
}

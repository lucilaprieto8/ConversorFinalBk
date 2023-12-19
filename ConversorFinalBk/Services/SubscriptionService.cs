using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace ConversorFinalBk.Services
{
    public class SubscriptionService
    {
        private readonly ConversorContext _conversorContext;
        private readonly SessionService _sessionService;
        public SubscriptionService(ConversorContext conversorContext, SessionService sessionService)
        {
            _conversorContext = conversorContext;
            _sessionService = sessionService;
        }

        public void UpdateSubscription(int id)
        {
            var IdUser = _sessionService.GetUserId();
            var userToUpdate = _conversorContext.User.FirstOrDefault(u => u.Id == IdUser);
            var hola = _conversorContext.Subscription.FirstOrDefault(i => i.Id == id);
            if (hola == null)
            {
                throw new Exception("no existe la sub");
            }
            userToUpdate.IdSubscription = id;
            
            _conversorContext.SaveChanges();
        }
        public List<Subscription> GetSubscription()
        {
            var userId = _sessionService.GetUserId();
            var use = _conversorContext.User.FirstOrDefault(u=> u.Id == userId);
            return _conversorContext.Subscription.Where(s => s.Id == use.IdSubscription).ToList();
        }
        public List<Subscription> GetAllSubscription()
        {
            var ok = _conversorContext.Subscription.ToList();
            return ok;
        }

    }
}

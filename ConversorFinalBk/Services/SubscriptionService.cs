using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;
using ConversorFinalBk.Models;

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

        public void UpdateSubscription(SubToUpdateDto dto)
        {
            var IdUser = _sessionService.GetUserId();
            var userToUpdate = _conversorContext.User.FirstOrDefault(u => u.Id == IdUser);
            var hola = _conversorContext.Subscription.FirstOrDefault(i => i.Id == dto.IdSubscription);
            if (hola == null)
            {
                throw new Exception("no existe la sub");
            }
            userToUpdate.IdSubscription = dto.IdSubscription;
            
            _conversorContext.SaveChanges();
        }
    }
}

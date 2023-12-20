using ConversorFinal_BE.Data;
using ConversorFinalBk.Entities;

namespace ConversorFinalBk.Services
{
    public class ConversionService
    {
        private readonly ConversorContext _conversorContext;
        private readonly SessionService _sessionService;
        public ConversionService(ConversorContext conversorContext, SessionService sessionService)
        {
            _conversorContext = conversorContext;
            _sessionService = sessionService;   
        }
        public List<Conversion> GetAll()
        {
            return _conversorContext.Conversion.ToList();
        }
        public int IncrementCounter()
        {
            var IdUser = _sessionService.GetUserId();
            var counter2 = _conversorContext.Conversion.FirstOrDefault(c => c.IdUser == IdUser);
            var user = _conversorContext.User.FirstOrDefault(c => c.Id == IdUser);
            var subs = _conversorContext.Subscription.FirstOrDefault(c => c.Id == user.IdSubscription);
            var restantes = subs.MaxAttemps - counter2.Attemps;
            if (counter2.FirstTry is null)
            {
                counter2.FirstTry = DateTime.Now;
            }
            this.UserRequestPerMonth();

            if (restantes >= 0)
            {
                counter2.Attemps++;
            }
            else
            {
                throw new Exception("Limite de request superado");
            }
            _conversorContext.Update(counter2);  
            return restantes;
        }        


        //esta func es para comprobar que si cambio de mes del primer request que hizo que reinicie el counter
        // de las attemps
        public bool UserRequestPerMonth() 
        {
            var IdUser = _sessionService.GetUserId();
            var requestDate = _conversorContext.Conversion.FirstOrDefault(c => c.IdUser == IdUser);
            if (( DateTime.Now - requestDate.FirstTry) > TimeSpan.FromDays(30))
            {
                requestDate.Attemps = 0;
                requestDate.FirstTry = DateTime.Now;
                _conversorContext.Update(requestDate);
                return true;
            }
            return false;
        }
    }
}

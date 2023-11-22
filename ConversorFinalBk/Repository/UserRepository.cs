using ConversorFinal_BE.Entities;

namespace ConversorFinalBk.Repository
{
    public class UserRepository
    {
        public User? Validate(string user, string password)
        {
            return null; // return FakeUsers.SingleOrDefault(x => x.UserName == user && x.Password == password);
        }
    }
}

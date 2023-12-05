using System.Security.Claims;

namespace ConversorFinalBk.Services
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int getOneById()
        {
            Claim? userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst("Id");

            if (userIdClaim == null)
            {
                throw new Exception("No se pudo iniciar sesión");

            }
            else
                return int.Parse(userIdClaim.Value);
        }

    }
}

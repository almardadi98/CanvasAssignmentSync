using System.Security.Claims;

namespace Domain.Repositories
{
    public interface IUserAccessor
    {
        public ClaimsPrincipal GetUser();
    }
}

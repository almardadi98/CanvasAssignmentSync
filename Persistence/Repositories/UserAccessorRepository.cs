using System.Security.Claims;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;

namespace Persistence.Repositories
{
    internal class UserAccessorRepository : IUserAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserAccessorRepository(IHttpContextAccessor accessor)
        {
            _contextAccessor = accessor;
        }

        public ClaimsPrincipal GetUser()
        {
            return _contextAccessor.HttpContext.User;
        }
    }
}

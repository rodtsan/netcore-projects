using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PinoyCode.Domain.Identity.Models;

namespace PinoyCode.Domain.Identity
{
    public class SignInManager : SignInManager<User>, ISignInManager
    {
        public SignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<User> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger)
        {

        }
    }

    
}

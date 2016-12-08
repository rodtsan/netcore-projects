using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using PinoyCode.Domain.Identity.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Identity
{
    public interface ISignInManager
    {
        Task<bool> CanSignInAsync(User user);
        Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure);
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(User user);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task ForgetTwoFactorClientAsync();
        IEnumerable<AuthenticationDescription> GetExternalAuthenticationSchemes();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);
        Task<User> GetTwoFactorAuthenticationUserAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<bool> IsTwoFactorClientRememberedAsync(User user);
        Task<SignInResult> PasswordSignInAsync(User user, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task RefreshSignInAsync(User user);
        Task RememberTwoFactorClientAsync(User user);
        Task SignInAsync(User user, bool isPersistent, string authenticationMethod = null);
        Task SignInAsync(User user, AuthenticationProperties authenticationProperties, string authenticationMethod = null);
        Task SignOutAsync();
        Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
        Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
        Task<User> ValidateSecurityStampAsync(ClaimsPrincipal principal);

    }
}
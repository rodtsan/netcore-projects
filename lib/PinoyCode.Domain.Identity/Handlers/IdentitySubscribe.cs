using Microsoft.Extensions.Logging;
using PinoyCode.Cqrs;
using PinoyCode.Domain.Identity.Commands;
using PinoyCode.Domain.Identity.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Identity.Handlers
{
    public class IdentitySubscribe : IIdentitySubscribe
        , ISubscribeTo<UserHasBeenCreated>
        , ISubscribeTo<UserSignedIn>
    {

        private readonly IUserManager _userManager;
        private readonly ISignInManager _signInManager;
        private readonly ILogger _logger;

        public IdentitySubscribe(IUserManager userManager,
            ISignInManager signInManager,
            ILogger logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public void Handle(UserSignedIn e)
        {
            e.SignedIn = true;
        }

        public void Handle(UserHasBeenCreated e)
        {
            e.Succeeded = true;
        }
    }

    public interface IIdentitySubscribe
    {
    }
}

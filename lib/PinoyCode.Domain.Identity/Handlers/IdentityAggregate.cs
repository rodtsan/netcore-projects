using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PinoyCode.Cqrs;
using PinoyCode.Data.Infrustracture;
using PinoyCode.Domain.Identity.Commands;
using PinoyCode.Domain.Identity.Events;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Identity.Handlers
{
    public class IdentityAggregate : Aggregate
        , IHandleCommand<CreateUserCommand>
        , IHandleCommand<PasswordSignInCommand>
        , IApplyEvent<UserHasBeenCreated>
        , IApplyEvent<UserSignedIn>
     {

        private readonly ILogger _logger;
        private readonly IUserManager _userManager;
        private readonly ISignInManager _signInManager;

        public IdentityAggregate(IDbContext context) 
            : base(context)
        {
            _logger = GetService<ILoggerFactory>().CreateLogger<IdentityAggregate>();
            _userManager = GetService<IUserManager>();
            _signInManager = GetService<ISignInManager>();
        }

        public IEnumerable Handle(CreateUserCommand c)
        {
            var user = new User
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                UserName = c.UserName,
                Email = c.Email
            };

            _userManager.CreateAsync(user, c.Password).ContinueWith(t =>
            {
                if (t.Result.Succeeded)
                {
                    c.Id = Id;
                    c.Succeeded = true;

                    _signInManager.SignInAsync(user, isPersistent: false).ContinueWith(_ =>
                    {
                        if (_.IsFaulted)
                            c.Message = _.Exception?.Message;
                        else if (_.IsCanceled)
                            c.Message = $"{c.GetType().Name}:Operation was cancelled";
                        else
                            c.SignedIn = true;

                    }, TaskContinuationOptions.None);


                    _logger.LogInformation(3, "User created a new account with password.");
                } else
                     c.Message = t.Exception?.Message;
            });

            c.HasError = !string.IsNullOrEmpty(c.Message);
         
            yield return c;
        }

        public IEnumerable Handle(PasswordSignInCommand c)
        {
            _signInManager.PasswordSignInAsync(c.Email, c.Password, c.RememberMe, lockoutOnFailure: false).ContinueWith(t =>
            {
                if (t.IsFaulted)
                    c.Message = t.Exception?.Message;
                else if (t.IsCanceled)
                    c.Message = $"{c.GetType().Name}:Operation was cancelled";
                else
                {
                    c.Succeeded = t.Result.Succeeded;
                    c.RequiresTwoFactor = t.Result.RequiresTwoFactor;
                    c.IsLockedOut = t.Result.IsLockedOut;
                    c.IsNotAllowed = t.Result.IsNotAllowed;
                }           
            });

            c.HasError = !string.IsNullOrEmpty(c.Message);

            yield return c;
        }

        public void Apply(UserSignedIn e)
        {
            if (e.SignedIn)
            {

            }
        }

        public void Apply(UserHasBeenCreated e)
        {
            if (e.Succeeded) {
            }
        }

        public Guid GetAggregateId()
        {
            return Guid.Parse("e384a125-64c3-4b46-9241-416c19e6befe");
        }


    }

}

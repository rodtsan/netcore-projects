using Microsoft.AspNetCore.Http;
using PinoyCode.Cqrs;
using PinoyCode.Data.Infrustracture;
using PinoyCode.Domain.Identity.Commands;
using PinoyCode.Domain.Identity.Events;
using PinoyCode.Domain.Identity.Models;
using System;
using System.Collections;

namespace PinoyCode.Domain.Identity.Handlers
{
    public class IdentityAggregate : Aggregate
        , IHandleCommand<CreateUserCommand>
        , IHandleCommand<UserSignInCommand>
        , IApplyEvent<UserHasBeenCreated>
        , IApplyEvent<UserSignedIn>
        , IIdentityAggregate
    {
        public IdentityAggregate(IDbContext context) 
            : base(context)
        {

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


            //GetService<UserManager>().CreateAsync(user, c.Password).ContinueWith(t =>
            //{
            //    c.Message = t.Exception.Message;
            //    if (t.Result.Succeeded)
            //    {

            //        Apply(new UserHasBeenCreated
            //        {
            //            Id = user.Id,
            //            User = user,
            //            Succeeded = c.Succeeded
            //        });

            //        c.Id = user.Id;
            //    }
            //});

        
            c.Id = Guid.NewGuid();

            yield return c;
        }

        public IEnumerable Handle(UserSignInCommand c)
        {
            //GetService<SignInManager>().SignInAsync(c.User, isPersistent: false).ContinueWith(t =>
            //{
            //    c.Message = t.Exception.Message;
            //    if (!t.IsFaulted) {
            //        c.SignedIn = true;
            //    }
            //});

            yield return c;
        }

        public void Apply(UserSignedIn e)
        {
            e.SignedIn = true;
        }

        public void Apply(UserHasBeenCreated e)
        {
            if (e.Succeeded) {
                Handle(new UserSignInCommand
                {
                    Id = e.Id,
                    User = e.User
                });
            }
             else throw new Exception("User account creation failed.");
        }

    }

    public interface IIdentityAggregate
    {
        Guid Id { get; }
        int EventsLoaded { get; }
        IEnumerable Handle(CreateUserCommand c);
        IEnumerable Handle(UserSignInCommand c);
        void Apply(UserHasBeenCreated e);
        void Apply(UserSignedIn e);
    }
}

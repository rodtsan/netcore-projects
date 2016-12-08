using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace PinoyCode.Domain.Identity.Models
{
    public class IdentityModel : IModel
    {
        public object this[[NotNullAttribute] string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IAnnotation FindAnnotation(string name)
        {
            throw new NotImplementedException();
        }

        public IEntityType FindEntityType(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEntityType> GetEntityTypes()
        {
            throw new NotImplementedException();
        }
    }
}

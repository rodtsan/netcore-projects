using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PinoyCode.Data.Infrastructure;

namespace PinoyCode.Data.Infrustracture
{
    public class BusinessObject : IBusinessObject
    {
        private readonly IDbContext _content;
        public BusinessObject(IDbContext content)
        {
            _content = content;
        }

        public IDbContext Context
        {
            get
            {
                return _content;
            }
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork(_content);
            }
        }
    }
}

using PinoyCode.Data.Infrustracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads.Repositories
{
    public class AdsBusinessObject : BusinessObject, IAdsBusinessObject
    {
        private readonly IDbContext _context;
        public AdsBusinessObject(IDbContext context)
            :base(context)
        {
            
        }

        public IAdPostRepository GetAdPostRepository()
        {
            return new AdPostRepository(Context);
        }

        public ICategoryRepository GetCategoryRepository()
        {
            return new CategoryRepository(Context);
        }
    }

    public interface IAdsBusinessObject : IBusinessObject
    {
        IAdPostRepository GetAdPostRepository();
        ICategoryRepository GetCategoryRepository(); 
    }
}

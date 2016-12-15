using PinoyCode.Data;
using PinoyCode.Data.Extensions;
using PinoyCode.Data.Infrustracture;
using PinoyCode.Domain.Ads.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads.Repositories
{
    public class AdPostRepository : EFRepository<AdPost>, IAdPostRepository
    {
        public AdPostRepository(IDbContext content) : base(content)
        {
        }
        public PagedList<AdPost> GetPaged(IPaged paged)
        {

            return TableNoTracking.PagedList(paged.PageIndex, paged.PageSize, paged.SearchByPropertyName, paged.SearchByText, paged.OrderByPropertyName, paged.OrderByDescending);
        }
    }

    public interface IAdPostRepository : IEFRepository<AdPost>
    {
        PagedList<AdPost> GetPaged(IPaged paged);
    }
}

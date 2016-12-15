using PinoyCode.Data;
using PinoyCode.Data.Extensions;
using PinoyCode.Data.Infrustracture;
using PinoyCode.Domain.Ads.Models;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace PinoyCode.Domain.Ads.Repositories
{
    using Microsoft.EntityFrameworkCore;
    public class CategoryRepository : EFRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext content) : base(content)
        {

        }

        public PagedList<Category> GetPaged(IPaged paged)
        {
            return TableNoTracking
                     .Where(p => p.ParentId == null) 
                     .Include(p => p.Categories)
                     .PagedList(paged.PageIndex, paged.PageSize, paged.SearchByPropertyName, paged.SearchByText, paged.OrderByPropertyName, paged.OrderByDescending);
        }
    }

    public interface ICategoryRepository : IEFRepository<Category>
    {
        PagedList<Category> GetPaged(IPaged paged);
    }
}

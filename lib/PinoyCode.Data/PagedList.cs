using PinoyCode.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PinoyCode.Data
{
    public class PagedList<T> : IPaged
    {
        private readonly IQueryable<T> _query;
        public PagedList(IQueryable<T> query)
        {
            _query = query;
        }

        public PagedList()
            : this(Enumerable.Empty<T>().AsQueryable())
        {
                
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderByPropertyName { get; set; }
        public bool OrderByDescending { get; set; }
        public string SearchByPropertyName { get; set; }
        public string SearchByText { get; set; }
        public int RecordCount
        {
            get
            {
                return _query.Count();
            }
        }
       
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((double)RecordCount / PageSize);
            }
        }
      
        public IEnumerable<T> Items
        {
            get
            {
                var q = _query;
                if (!string.IsNullOrWhiteSpace(SearchByPropertyName) && !string.IsNullOrWhiteSpace(SearchByText))
                    q = q.Where($"{SearchByPropertyName}.StartsWith(@0)", SearchByText);

                if (!string.IsNullOrWhiteSpace(OrderByPropertyName))
                {
                    if (OrderByDescending)
                        q = q.OrderByDescending(OrderByPropertyName);
                    else
                        q = q.OrderBy(OrderByPropertyName);
                }


                return q.AsEnumerable<T>();
            }
        }
       
    }


    public interface IPaged
    {
        int RecordCount { get; }
        int PageIndex { get; set; }
        int PageCount { get; }
        int PageSize { get; set; }
        string OrderByPropertyName { get; set; }
        bool OrderByDescending { get; set; }
        string SearchByPropertyName { get; set; }
        string SearchByText { get; set; }
    }
}

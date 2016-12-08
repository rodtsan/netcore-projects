using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  PinoyCode.Cqrs.Models
{
    public class Aggregate
    {
        public Guid Id { get; set; }
        public string AggregateType { get; set; }
        public DateTime CommitDateTime { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        public Aggregate()
        {
            this.Id = Guid.NewGuid();
        }
    }
}

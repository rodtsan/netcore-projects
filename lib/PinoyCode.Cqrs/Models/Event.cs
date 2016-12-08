using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Cqrs.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public DateTime CommitDateTime { get; set; }
        public int SequenceNumber { get; set; }
        public Guid AggregateId { get; set; }
        public virtual Aggregate Aggregate { get; set; }

        public Event()
        {
            this.Id = Guid.NewGuid();
        }
    }
}

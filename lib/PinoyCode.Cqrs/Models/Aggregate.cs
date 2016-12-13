using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinoyCode.Cqrs.Models
{
    public class Aggregate
    {
        public Guid Id { get; set; }
        public string AggregateType { get; set; }
        [Required]
        public DateTime CommitDateTime { get; set; }
        public virtual ICollection<Event> Events { get; set; }

        public Aggregate()
        {
            this.Id = Guid.NewGuid();
            this.Events = new HashSet<Event>();
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PinoyCode.Cqrs.Models
{
    public class Event
    {
        [Key, Required]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        [Required]
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

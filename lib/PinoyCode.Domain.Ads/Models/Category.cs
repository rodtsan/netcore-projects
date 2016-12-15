using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads.Models
{
    public class Category 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Title { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        [NotMapped]
        public int? ChildCount {
            get
            {
                return Categories?.Count();
            }
        }
        public int Order { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? CreatedById { get; set; }
        public bool Disabled { get; set; }
        public Category()
        {
            Categories = new HashSet<Category>();
        }
    }
}

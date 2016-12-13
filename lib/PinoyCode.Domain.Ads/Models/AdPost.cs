using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads.Models
{
    public class AdPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(256)]
        public string Title { get; set; }
        public AdType Type { get; set; }
        public double Price { get; set; }
        [MaxLength(4000)]
        public string Description { get; set; }
        public int Order { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int? CreatedById { get; set; }
        public bool Disabled { get; set; }
        public ICollection<AdPostImage> Images { get; set; }
        public virtual FeaturedAd FeaturedAd { get; set; }
        public AdPost()
        {
            Images = new HashSet<AdPostImage>();
        }
    }

    public enum AdType
    {
        ItemForSale,
        BuyAnItem,
        FreeItem
    }
}

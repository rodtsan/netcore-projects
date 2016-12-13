using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads.Models
{
    public class FeaturedAd
    {
        [Key, ForeignKey("PostId")]
        public int PostId { get; set; }
        public virtual AdPost AdPost { get; set; }
        public int? FeaturedById { get; set;}
        public DateTime? FeaturedOnUtc { get; set; }
        public DateTime ExpiredOnUtc { get; set; }

    }
}

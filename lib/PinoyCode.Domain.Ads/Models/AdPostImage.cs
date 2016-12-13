using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PinoyCode.Domain.Ads.Models
{
    public class AdPostImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AdPostId { get; set; }
        public virtual AdPost AdPost { get; set; }
        [MaxLength(256)]
        public string ImageName { get; set; }
        [MaxLength(32)]
        public string ImageType { get; set; }
        public byte[] ImageData { get; set; }
    }
}

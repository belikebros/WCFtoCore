using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFService.Models
{
    public class userProfileImageModel
    {
        public int ImageId { get; set; }
        public Nullable<int> UserId { get; set; }
        public byte[] ImageData { get; set; }
        public string FileName { get; set; }
        public Nullable<int> ImageSize { get; set; }        
    }
}

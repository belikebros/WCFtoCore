using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFService.Models
{
    public class userFilesCollectonModel
    {
        public int FileId { get; set; }
        public Nullable<int> UserId { get; set; }
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FileContentType { get; set; }
        public string FileExtension { get; set; }
    }
}

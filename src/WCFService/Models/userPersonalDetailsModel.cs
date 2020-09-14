using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFService.DataAccessLayer;

namespace WCFService.Models
{
    public class userPersonalDetailsModel
    {
        public int id { get; set; }
        public string Gender { get; set; }
        public string Ethnicity { get; set; }
        public string Race { get; set; }
        public string TechnologyIntersted { get; set; }
        public Nullable<int> userId { get; set; }

        public virtual tbl_userDetails tbl_userDetails { get; set; }
    }
}

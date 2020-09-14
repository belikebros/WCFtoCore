using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFService.DataAccessLayer;

namespace WCFService
{
    public class userDetailsModel
    {
            public int userId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string emailId { get; set; }
            public System.DateTime dateOfBirth { get; set; }
            public string password { get; set; }
            public bool isEmailVerified { get; set; }
            public System.Guid activationCode { get; set; }
            public string resetPasswordCode { get; set; }
            public virtual ICollection<tbl_userPersonalDetail> tbl_userPersonalDetail { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace WCFService.Profiles
{
    public class ApplicationProfiles : Profile
    {
        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<DataAccessLayer.tbl_userDetails, userDetailsModel>();
            }
        }

        //public ApplicationProfiles()
        //{
        //    Mapper.Initialize(
        //        cfg => cfg.AddProfile<Profiles.ApplicationProfiles>());
        //    CreateMap<DataAccessLayer.tbl_userDetails, userDetailsModel>();
        //}
    }
}

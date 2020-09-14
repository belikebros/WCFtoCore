using System;
using System.Collections.Generic;
using System.ServiceModel;
using WCFService.DataAccessLayer;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataQuadService" in both code and config file together.
    [ServiceContract]
    public interface IDataQuadService
    {
        [OperationContract]
        //WCFService.DataQuadService.tbl_userDetails GetUserDetailByUserId(int id);
        userDetailsModel GetUserDetailByUserId(int id);
        [OperationContract]
        string sample();
        [OperationContract]
        bool RegisterUser(userDetailsModel user);

        [OperationContract]
        Models.userProfileImageModel GetProfileImageByUserId(int? id);

        [OperationContract]
        void SaveProfileImage(tbl_userProfileImages image);

        [OperationContract]
        Models.userPersonalDetailsModel GetPersonalDetailByUserId(int id);

        [OperationContract]
        void SavePersonalDetail(tbl_userPersonalDetail userPersonalDetail);

        [OperationContract]
        IEnumerable<tbl_race> GetAllRaces();

        [OperationContract]
        IEnumerable<tbl_userFilesCollection> GetAllFilesByUserId(int id);

        [OperationContract]
        Models.userFilesCollectonModel GetFileByFileId(int id);

        [OperationContract]
        void SaveFile(tbl_userFilesCollection file);

        [OperationContract]
        void DeleteFile(int id);

    }
}

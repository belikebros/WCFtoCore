using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

using WCFService.DataAccessLayer;
using WCFService.Models;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataQuadService" in both code and config file together.
    public class DataQuadService : IDataQuadService
    {
        public DataquadEntities db;
        public DataQuadService(DataquadEntities _db)
        {
            db = _db;
        }
        public void DeleteFile(int id)
        {
            var fileToDelete = db.tbl_userFilesCollection.Where(x => x.FileId == id).FirstOrDefault();
            db.tbl_userFilesCollection.Remove(fileToDelete);
            db.SaveChanges();
        }

        public IEnumerable<tbl_userFilesCollection> GetAllFilesByUserId(int id)
        {
            return db.tbl_userFilesCollection.Where(x => x.UserId == id).ToList();
        }

        public IEnumerable<tbl_race> GetAllRaces()
        {
            return db.tbl_race.ToList();
        }

        public Models.userFilesCollectonModel GetFileByFileId(int id)
        {
            var fileFromDb = db.tbl_userFilesCollection.FirstOrDefault(x => x.FileId == id);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<tbl_userFilesCollection, Models.userFilesCollectonModel>();
            });

            //Initiliazing or create an instance of mapper
            AutoMapper.IMapper mapper = config.CreateMapper();

            //Automapping userDetailsFromDb to userDetailsModel
            var requestedFile = mapper.Map<Models.userFilesCollectonModel>(fileFromDb);

            return requestedFile;

        }

        public userPersonalDetailsModel GetPersonalDetailByUserId(int id)
        {
            throw new NotImplementedException();
        }

        //public tbl_userPersonalDetail GetPersonalDetailByUserId(int id)
        //{
        //    return db.tbl_userPersonalDetail.FirstOrDefault(x => x.userId == id);
        //}

        //public Models.userPersonalDetailsModel GetPersonalDetailByUserId(int id)
        //{
        //    var userPersonalDetailsFromDb = db.tbl_userPersonalDetail.Where(x => x.userId == id).FirstOrDefault();
        //    //Creating AutoMapper Map for tbl_userDetails as source and userDetailsModel as destination
        //    var config = new AutoMapper.MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<DataAccessLayer.tbl_userPersonalDetail, Models.userPersonalDetailsModel>();
        //    });

        //    //Initiliazing or create an instance of mapper
        //    AutoMapper.IMapper mapper = config.CreateMapper();

        //    //Automapping userDetailsFromDb to userDetailsModel
        //    var userDetailsModel = mapper.Map<tbl_userPersonalDetail, userDetailsModel>(userPersonalDetailsFromDb);
        //    return userDetailsModel;
        //}

        public Models.userProfileImageModel GetProfileImageByUserId(int? id)
        {
            //Models.userProfileImageModel userProfileImage = new Models.userProfileImageModel();
            var userProfileImageFromDb = db.tbl_userProfileImages.FirstOrDefault(x => x.UserId == id);
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataAccessLayer.tbl_userProfileImages, Models.userProfileImageModel>();
            });

            //Initiliazing or create an instance of mapper
            AutoMapper.IMapper mapper = config.CreateMapper();

            //Automapping userDetailsFromDb to userDetailsModel
            var userProfileImage = mapper.Map<Models.userProfileImageModel>(userProfileImageFromDb);

            return userProfileImage;
        }

        public userDetailsModel GetUserDetailByUserId(int id)
        {
            //userDetailsModel user = new userDetailsModel();

            var userDetailsFromDb = db.tbl_userDetails.Where(x => x.userId == id).FirstOrDefault();
            //Creating AutoMapper Map for tbl_userDetails as source and userDetailsModel as destination
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataAccessLayer.tbl_userDetails, userDetailsModel>();
            });

            //Initiliazing or create an instance of mapper
            AutoMapper.IMapper mapper = config.CreateMapper();

            //Automapping userDetailsFromDb to userDetailsModel
            var userDetailsModel = mapper.Map<tbl_userDetails, userDetailsModel>(userDetailsFromDb);

            #region copying data from database table to view model by each property
            //user.userId = data.userId;
            //user.FirstName = data.FirstName;
            //user.LastName = data.LastName;
            //user.password = data.password;
            //user.resetPasswordCode = data.resetPasswordCode;
            //user.dateOfBirth = data.dateOfBirth;
            //user.emailId = data.emailId;
            //user.activationCode = data.activationCode;
            //user.isEmailVerified = data.isEmailVerified;
            //user.tbl_userPersonalDetail = data.tbl_userPersonalDetail; 
            #endregion

            return userDetailsModel;

        }

        public bool RegisterUser(userDetailsModel user)
        {
            var hashedPassword = Crypto.Hash(user.password);
            user.password = hashedPassword;

            #region AutoMapper
            //Creating AutoMapper Map for tbl_userDetails as source and userDetailsModel as destination
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<userDetailsModel, DataAccessLayer.tbl_userDetails>();
            });

            //Initiliazing or create an instance of mapper
            AutoMapper.IMapper mapper = config.CreateMapper();

            //Automapping userDetailsFromDb to userDetailsModel
            var tbl_user = mapper.Map<tbl_userDetails>(user);
            #endregion

            if (tbl_user != null)
            {
                db.tbl_userDetails.Add(tbl_user);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public string sample()
        {
            return "test success";
        }

        public void SaveFile(tbl_userFilesCollection file)
        {
            db.tbl_userFilesCollection.Add(file);
            db.SaveChanges();
        }

        public void SavePersonalDetail(tbl_userPersonalDetail userPersonalDetail)
        {
            db.tbl_userPersonalDetail.Add(userPersonalDetail);
            db.SaveChanges();

        }

        public void SaveProfileImage(tbl_userProfileImages image)
        {
            image.FileName = image.File.FileName;
            image.ImageSize = Convert.ToInt32(image.File.Length);

            byte[] data = new byte[Convert.ToInt32(image.File.Length)];
            image.File.OpenReadStream().Read(data, 0, Convert.ToInt32(image.File.Length));

            image.ImageData = data;
            var imageFromDB = GetProfileImageByUserId(image.UserId);
            if (imageFromDB == null)
            {
                db.tbl_userProfileImages.Add(image);
                db.SaveChanges();
            }
            else
            {
                imageFromDB.FileName = image.FileName;
                imageFromDB.ImageData = data;
                imageFromDB.ImageSize = image.ImageSize;
                imageFromDB.UserId = image.UserId;
                db.SaveChanges();
            }
        }

    }
}

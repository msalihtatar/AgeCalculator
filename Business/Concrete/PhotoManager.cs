using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PhotoManager : IPhotoService
    {
        IPhotoDal _photoDal;
        public PhotoManager(IPhotoDal photoDal)
        {
            _photoDal = photoDal;
        }
        public IDataResult<int> Add(string photoFile)
        {
            try
            {
                var isAdded = _photoDal.Add(photoFile);
                if (isAdded > 0)
                {
                    return new SuccessDataResult<int>(isAdded,"Fotoğraf eklendi.");
                }
                else
                {
                    return new ErrorDataResult<int>("Fotoğraf eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IDataResult<List<Photo>> GetAll()
        {
            try
            {
                var photoList = _photoDal.GetAll();
                if (photoList != null && photoList.Count > 0)
                {
                    return new SuccessDataResult<List<Photo>>("Fotoğraflar getirildi.");
                }
                else
                {
                    return new ErrorDataResult<List<Photo>>("Fotoğraf bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IDataResult<Photo> GetByPhotoID(int photoID)
        {
            try
            {
                var photo = _photoDal.GetByPhotoID(photoID);
                if (photo != null)
                {
                    return new SuccessDataResult<Photo>("Fotoğraf getirildi.");
                }
                else
                {
                    return new ErrorDataResult<Photo>("Fotoğraf bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

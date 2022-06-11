using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IPhotoDal
    {
        int Add(string photoFile);
        bool Delete(int photoID);
        bool Update(int photoID, string photoFile);
        List<Photo> GetAll();
        Photo GetByPhotoID(int photoID);
    }
}

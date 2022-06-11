using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPhotoService
    {
        IDataResult<int> Add(string photoFile);
        IDataResult<List<Photo>> GetAll();
        IDataResult<Photo> GetByPhotoID(int photoID);
    }
}

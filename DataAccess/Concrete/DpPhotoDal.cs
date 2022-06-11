using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class DpPhotoDal : IPhotoDal
    {
        IDbConnection _dbConnection;
        public DpPhotoDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public int Add(string photoFile)
        {
            try
            {
                string sql = string.Format(@"Insert Into Photo(PhotoFile) Values('{0}')", photoFile);

                var photoID = _dbConnection.ExecuteScalar(sql);
                return (int)photoID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int photoID)
        {
            try
            {
                string sql = @"Delete From Photo where PhotoID = " + photoID;

                _dbConnection.Execute(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Photo> GetAll()
        {
            try
            {
                string sql = @"Select * From Photo";

                var photoList = _dbConnection.Query<Photo>(sql).ToList();
                return photoList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Photo GetByPhotoID(int photoID)
        {
            try
            {
                string sql = @"Select * From Photo Where PhotoID = " + photoID;

                var photo = _dbConnection.Query<Photo>(sql).FirstOrDefault();
                return photo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(int photoID, string photoFile)
        {
            try
            {
                string sql = string.Format(@"Update Photo Set PhotoFile = '{0}' Where PhotoID = {1}", photoFile, photoID);

                _dbConnection.Execute(sql);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

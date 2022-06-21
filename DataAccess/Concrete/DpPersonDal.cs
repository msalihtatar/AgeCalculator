using Dapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DpPersonDal : IPersonDal
    {
        IDbConnection _dbConnection;
        public DpPersonDal(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public bool Add(Person person)
        {
            try
            {
                string sql = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                            @"Insert Into [Person]([PhotoFile], [CityID],[Name], [Surname], [Age], [BirthDate], [Gender])
                            Values(@PhotoFile, @CityID, @Name, @Surname, @Age, @BirthDate, @Gender)");

                _dbConnection.Execute(sql, new
                {
                    person.PhotoFile,
                    person.CityID,
                    person.Name,
                    person.Surname,
                    person.Age,
                    person.BirthDate,
                    person.Gender
                });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Person> GetAll()
        {
            try
            {
                string sql = @"Select * from Person";

                var personList = _dbConnection.Query<Person>(sql).ToList();
                return personList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<PersonDetailDTO>> GetAllPersonDetailsAsync()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_dbConnection.ConnectionString))
                {
                    await conn.OpenAsync();
                    string sql = @"Select * from Person p
                               Inner Join City c on c.CityID = p.CityID";
                    var personList = (await conn.QueryAsync<PersonDetailDTO>(sql)).ToList();

                    return personList;
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonDetailDTO> GetAllPersonDetails()
        {
            try
            {
                string sql = @"Select * from Person p
                            Inner Join City c on c.CityID = p.CityID";
                var personList = _dbConnection.Query<PersonDetailDTO>(sql).ToList();

                return personList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Person GetByPersonID(int personID)
        {
            try
            {
                string sql = @"Select * from Person where PersonID = " + personID;

                var person = _dbConnection.Query<Person>(sql).FirstOrDefault();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonDetailDTO GetPersonDetailsByID(int personID)
        {
            try
            {
                string sql = @"Select c.CityName, ph.PhotoFile, p.* from Person p
                               Inner Join City c on c.CityID = p.CityID
                               Left Join Photo ph on ph.PhotoID = p.PhotoID
                               Where PersonID = " + personID;

                var person = _dbConnection.Query<PersonDetailDTO>(sql).FirstOrDefault();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

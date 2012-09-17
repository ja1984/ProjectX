using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ProjectX.Models;
using DapperExtensions;

namespace ProjectX.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int id);
        int Add(User user);
    }


    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> Get()
        {

            IEnumerable<User> result;

            using (SqlConnection connection = new SqlConnection(ConfigSettings.ConnectionString))
            {

                connection.Open();
                result = connection.GetList<User>().ToList();
                connection.Close();
            }

            return result;
        }

        public User Get(int id)
        {

            User user;

            using (SqlConnection connection = new SqlConnection(ConfigSettings.ConnectionString))
            {

                connection.Open();
                user = connection.Get<User>(id);
                connection.Close();
            }

            return user;
        }

        public int Add(User user)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(ConfigSettings.ConnectionString))
            {
                connection.Open();
                id = connection.Insert<User>(user);
                connection.Close();
            }
            return id;
        }
    }
}
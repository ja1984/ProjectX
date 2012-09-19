using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ProjectX.Models;
using DapperExtensions;
using Dapper;

namespace ProjectX.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int id);
        int Add(User user);
        User Login(string login);
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

        public User Login(string login)
        {

            User user;

            using (var connection = new SqlConnection(ConfigSettings.ConnectionString))
            {
                connection.Open();
                user = connection.Query<User>("SELECT * FROM [User] WHERE [Username] = @Login OR [Email] = @Login", new { Login = login }).FirstOrDefault();
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
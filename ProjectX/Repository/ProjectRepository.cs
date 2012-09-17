using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectX.Models;
using DapperExtensions;
using System.Data.SqlClient;

namespace ProjectX.Repository
{

    public interface IProjectRepository
    {
        IEnumerable<Project> Get();
        Project Get(int id);
        int Add(Project project);
    }

    public class ProjectRepository: IProjectRepository
    {
        public IEnumerable<Project> Get()
        {
            IEnumerable<Project> result;

            using (SqlConnection connection = new SqlConnection(ConfigSettings.ConnectionString))
            {
                connection.Open();
                result = connection.GetList<Project>().ToList();
                connection.Close();
            }

            return result;
        }



        public Project Get(int id)
        {
            Project project;

            using (SqlConnection connection = new SqlConnection(ConfigSettings.ConnectionString))
            {
                connection.Open();
                project = connection.Get<Project>(id);
                connection.Close();

            }

            return project;
        }

        public int Add(Project project)
        {
            int id;
            using (SqlConnection connection = new SqlConnection(ConfigSettings.ConnectionString))
            {
                connection.Open();
                id = connection.Insert<Project>(project);
                connection.Close();
            }
            return id;
        }

    }
}
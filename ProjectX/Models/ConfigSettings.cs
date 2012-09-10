using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProjectX.Models
{
    public class ConfigSettings
    {
        private static string GetSetting(string key, string defaultValue)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[""].ConnectionString;
        }

        public static string ConnectionString
        {
            get { return GetConnectionString(); }
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using ProjectX.Models;
using System.Text;
using System.Web.Security;

namespace ProjectX.Helpers
{
    public static class HelperService
    {
        //public static string GenerateSlug(string name)
        //{
        //    // make the url lowercase
        //    string encodedUrl = (name ?? "").ToLower();

        //    encodedUrl = encodedUrl.Replace("å", "a");
        //    encodedUrl = encodedUrl.Replace("ä", "a");
        //    encodedUrl = encodedUrl.Replace("ö", "o");

        //    // replace & with and
        //    encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");

        //    // remove characters
        //    encodedUrl = encodedUrl.Replace("'", "");

        //    // remove invalid characters
        //    encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

        //    // remove duplicates
        //    encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

        //    // trim leading & trailing characters
        //    encodedUrl = encodedUrl.Trim('-');

        //    return encodedUrl;

        //}

        //public static string GetGravatar(string email, ProfileImageSize imageSize)
        //{
        //    using (MD5 md5Hash = MD5.Create())
        //    {
        //        return string.Format("http://www.gravatar.com/avatar/{0}?s={1}&d=mm", GetMd5Hash(md5Hash, email), (int)imageSize);
        //    }
        //}

        //private static string GetMd5Hash(MD5 md5Hash, string input)
        //{

        //    // Convert the input string to a byte array and compute the hash. 
        //    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        //    // Create a new Stringbuilder to collect the bytes 
        //    // and create a string.
        //    StringBuilder sBuilder = new StringBuilder();

        //    // Loop through each byte of the hashed data  
        //    // and format each one as a hexadecimal string. 
        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }

        //    // Return the hexadecimal string. 
        //    return sBuilder.ToString();
        //}


        //public static string GenerateSalt(string username)
        //{
        //    string toBeHashed = username.Substring(0, 1);
        //    toBeHashed += username.Length;
        //    toBeHashed += username.Substring(username.Length - 1, 1);

        //    return GetMd5Hash(MD5.Create(), toBeHashed);
        //}

        //public static string GenerateHash(string salt, string password)
        //{
        //    return FormsAuthentication.HashPasswordForStoringInConfigFile(string.Concat(salt, password), "SHA1");
        //}


    }
}
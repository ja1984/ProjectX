﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using ProjectX.Models;

namespace ProjectX.Helpers
{
    public class MemberHelper
    {


        //public string GetGravatar(string email, ProfileImageSize imageSize)
        //{
        //    using (MD5 md5Hash = MD5.Create())
        //    {

        //        return string.Format("http://www.gravatar.com/avatar/{0}?s={1}&d=mm", GetMd5Hash(md5Hash, email), (int)imageSize);
        //    }
        //}

        //private string GetMd5Hash(MD5 md5Hash, string input)
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


    }
}
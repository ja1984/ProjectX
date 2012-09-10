using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ProjectX.Helpers
{
    public static class HelperService
    {
        public static string GenerateSlug(string name)
        {
            // make the url lowercase
            string encodedUrl = (name ?? "").ToLower();

            encodedUrl = encodedUrl.Replace("å", "a");
            encodedUrl = encodedUrl.Replace("ä", "a");
            encodedUrl = encodedUrl.Replace("ö", "o");

            // replace & with and
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");

            // remove characters
            encodedUrl = encodedUrl.Replace("'", "");

            // remove invalid characters
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

            // remove duplicates
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

            // trim leading & trailing characters
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;

        }
    }
}
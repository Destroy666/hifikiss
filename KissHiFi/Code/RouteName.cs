using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace KissHiFi.Code
{
    public class RouteName
    {
        public string RouteNev(string route)
        {
            route = route.ToLower();

            StringBuilder sb = new StringBuilder(route);
            sb.Replace("á", "a");
            sb.Replace("é", "e");
            sb.Replace("í", "i");
            sb.Replace("ó", "o");
            sb.Replace("ö", "o");
            sb.Replace("ő", "o");
            sb.Replace("ú", "u");
            sb.Replace("ü", "u;");
            sb.Replace("ű", "u;");
            sb.Replace(" ", "-");
            route = sb.ToString();

            route = Regex.Replace(route, @"[^0-9a-zA-Z\-_]", string.Empty);

            return route;
        }

        public string FileNev(string fName)
        {
            fName = fName.ToLower();

            StringBuilder sb = new StringBuilder(fName);
            sb.Replace("á", "a");
            sb.Replace("é", "e");
            sb.Replace("í", "i");
            sb.Replace("ó", "o");
            sb.Replace("ö", "o");
            sb.Replace("ő", "o");
            sb.Replace("ú", "u");
            sb.Replace("ü", "u;");
            sb.Replace("ű", "u;");
            sb.Replace(" ", "-");
            fName = sb.ToString();

            fName = Regex.Replace(fName, @"[^0-9a-zA-Z\-_.]", string.Empty);

            return fName;
        }
    }
}
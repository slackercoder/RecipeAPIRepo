using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeAPI.Helpers
{
    public static class ExtensionMethods
    {
        public static String Strip(this String str, String[] toStrip)
        {
            foreach (String s in toStrip)
            {
                str = str.Replace(s, "");
            }

            return str;
        }
    }
}
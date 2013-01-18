using RecipeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeAPI.Helpers
{
    public static class HelperMethods
    {
        public static bool LogError(int versionId, String message, String inner = "")
        {
            using (RecipeAPIEntities db = new RecipeAPIEntities())
            {
                try
                {
                    ErrorLog el = new ErrorLog()
                    {
                        APIVersionId = versionId,
                        Name = "",
                        Message = message + inner ?? "",
                    };

                    db.ErrorLogs.Add(el);
                    db.SaveChanges();

                    return true;
                }

                catch
                {
                    return false;
                }
            }
        }
    }
}
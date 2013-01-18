using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RecipeAPI.Models;
using RecipeAPI.Helpers;
using System.Net.Http.Formatting;

namespace RecipeAPI.Controllers
{
    public class v1Controller : ApiController
    {
        public const int VERSIONID = 1; //TODO: Can this come out of the DB on load or something?

        [HttpGet]
        public String Verison()
        {
            using (RecipeAPIEntities db = new RecipeAPIEntities())
            {
                try
                {
                    return db.Versions.Where(o => o.VersionId == 1).Select(o => o.Version1).First();
                }
                catch (Exception e)
                {
                    HelperMethods.LogError(VERSIONID, e.Message, e.InnerException == null ? String.Empty : e.InnerException.Message);
                    return "";
                }
            }
        }

        [HttpPost]
        public bool AddIngredient(String apiKey, String name)
        {
            using (RecipeAPIEntities db = new RecipeAPIEntities())
            {
                try
                {
                //    String apiKey = form.Get("apiKey");
                  //  String name = form.Get("name");

                    Member mem = db.Members.Where(o => o.ApiKey == apiKey).FirstOrDefault();

                    if (mem == null)
                        throw new Exception("The key you provided was not found. Please try again with a proper key");

                    Ingredient ing = new Ingredient()
                    {
                        Name = name
                    };

                    db.Ingredients.Add(ing);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    HelperMethods.LogError(VERSIONID, e.Message, e.InnerException == null ? String.Empty : e.InnerException.Message);
                    return false;
                }
            }
        }

        [HttpPost]
        public bool AddMeasurement(String apiKey, String name)
        {
            using (RecipeAPIEntities db = new RecipeAPIEntities())
            {
                try
                {
                    Member mem = db.Members.Where(o => o.ApiKey == apiKey).FirstOrDefault();

                    if (mem == null)
                        throw new Exception("The key you provided was not found. Please try again with a proper key");

                    Measurement meas = new Measurement()
                    {
                        Name = name
                    };

                    db.Measurements.Add(meas);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    HelperMethods.LogError(VERSIONID, e.Message, e.InnerException == null ? String.Empty : e.InnerException.Message);
                    return false;
                }
            }
        }

        [HttpPost]
        public bool AddRecipe(String apiKey, String name, String notes = "")
        {
            using (RecipeAPIEntities db = new RecipeAPIEntities())
            {
                try
                {
                    Member mem = db.Members.Where(o => o.ApiKey == apiKey).FirstOrDefault();

                    if (mem == null)
                        throw new Exception("The key you provided was not found. Please try again with a proper key");

                    Recipe rec = new Recipe()
                    {
                        Name = name,
                        Notes = notes
                    };

                    db.Recipes.Add(rec);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    HelperMethods.LogError(VERSIONID, e.Message, e.InnerException == null ? String.Empty : e.InnerException.Message);
                    return false;
                }
            }
        }

        
        [ActionName("CreateMember")]
        [HttpPost]
        public String CreateNewMember(String apiKey)
        {
            using (RecipeAPIEntities db = new RecipeAPIEntities())
            {
                try
                {
                    Member mem = db.Members.Where(o => o.ApiKey == apiKey).FirstOrDefault();

                  //  if (mem == null)
                  //      throw new Exception("The key you provided was not found. Please try again with a proper key");

                    String newMemberKey = Guid.NewGuid().ToString().Strip(new String[]{"-", "{", "}"}).Substring(0,20);

                    Member member = new Member()
                    {
                        ApiKey = newMemberKey
                    };

                    db.Members.Add(member);
                    db.SaveChanges();

                    return newMemberKey;
                }
                catch (Exception e)
                {
                    HelperMethods.LogError(VERSIONID, e.Message, e.InnerException == null ? String.Empty : e.InnerException.Message);
                    return String.Empty;
                }
            }
        }
    }
}

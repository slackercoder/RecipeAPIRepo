//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public Recipe()
        {
            this.IngredientLists = new HashSet<IngredientList>();
            this.InstructionLists = new HashSet<InstructionList>();
        }
    
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    
        public virtual ICollection<IngredientList> IngredientLists { get; set; }
        public virtual ICollection<InstructionList> InstructionLists { get; set; }
    }
}

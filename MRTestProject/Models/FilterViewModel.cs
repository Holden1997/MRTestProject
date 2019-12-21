using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRTestProject.Models
{
    public class FilterViewModel
    {

        public FilterViewModel(IList<CategoryViewModel> categories, Guid? category , string name)
        {
            categories.Insert(0, new CategoryViewModel { Name = "All", CategoryId = new Guid() });
            Categories = new SelectList(categories, "CategoryId", "Name", category);
            SelectedCategory = category;
            SelectedName = name;

        }
        public SelectList Categories { get; private set; } 
        public Guid? SelectedCategory { get; private set; }   
        public string SelectedName { get; private set; }   
    }
}

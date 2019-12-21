using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRTestProject.Models
{
    public class BaseViewModel
    {
        public List<SelectListItem> Categories { get; set; }
        public ProductViewModel Product { get; set; }
        public Guid CategoryId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public FilterViewModel FilterViewModel { get; set; }  
    }
}

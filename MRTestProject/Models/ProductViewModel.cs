using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRTestProject.Models
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public CategoryViewModel Category { get; set; }

        public FilterViewModel FilterViewModel { get; set; }

    }
}

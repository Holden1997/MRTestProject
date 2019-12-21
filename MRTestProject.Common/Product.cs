using System;
using System.Collections.Generic;
using System.Text;

namespace MRTestProject.Common
{
    public class Product 
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

    }
}

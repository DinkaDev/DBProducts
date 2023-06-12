using System;
using System.Collections.Generic;

namespace Task5._1.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

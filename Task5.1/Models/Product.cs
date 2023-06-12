using System;
using System.Collections.Generic;

namespace Task5._1.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            KeyParams = new HashSet<KeyParam>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public double ActionPrice { get; set; }
        public string Description { get; set; } = null!;
        public string DescriptionField1 { get; set; } = null!;
        public string DescriptionField2 { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<KeyParam> KeyParams { get; set; }
    }
}

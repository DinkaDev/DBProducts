using System;
using System.Collections.Generic;

namespace Task5._1.Models
{
    public partial class Cart
    {
        public Guid Id { get; set; }
        public Guid UsersUserId { get; set; }
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User UsersUser { get; set; } = null!;
    }
}

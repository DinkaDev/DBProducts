using System;
using System.Collections.Generic;

namespace Task5._1.Models
{
    public partial class KeyParam
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid KeyWordsId { get; set; }

        public virtual Word KeyWords { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Task5._1.Models
{
    public partial class Word
    {
        public Word()
        {
            KeyParams = new HashSet<KeyParam>();
        }

        public Guid Id { get; set; }
        public string Header { get; set; } = null!;
        public string KeyWord { get; set; } = null!;

        public virtual ICollection<KeyParam> KeyParams { get; set; }
    }
}

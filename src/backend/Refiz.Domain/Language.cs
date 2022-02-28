using System;
using System.Collections.Generic;

namespace Refiz.Domain
{
    public partial class Language
    {
        public Language()
        {
            Countries = new HashSet<Country>();
        }

        public byte Idlanguage { get; set; }
        public string Code { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}

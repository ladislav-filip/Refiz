using System;
using System.Collections.Generic;

namespace Scafold
{
    public partial class Setting
    {
        public string Key { get; set; } = null!;
        public string? Value { get; set; }
        public byte? Idlanguage { get; set; }

        public virtual Language? IdlanguageNavigation { get; set; }
    }
}

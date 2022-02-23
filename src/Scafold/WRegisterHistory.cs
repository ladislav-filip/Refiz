using System;
using System.Collections.Generic;

namespace Scafold
{
    public partial class WRegisterHistory
    {
        public int IdregisterHistory { get; set; }
        public long Idlog { get; set; }
        public int Idregister { get; set; }
        public DateTime DateCreate { get; set; }
        public byte LogLevel { get; set; }
        public string? Event { get; set; }
        public string Msg { get; set; } = null!;
        public string? Data { get; set; }
        public int? Identity { get; set; }
        public int? RegNumber { get; set; }
        public string NameSubject { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public int Idrole { get; set; }
        public string? OrgName { get; set; }
        public string GroupCode { get; set; } = null!;
        public string GroupResKey { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

namespace Scafold
{
    public partial class WRegister
    {
        public int Idregister { get; set; }
        public string Code { get; set; } = null!;
        public int? RegNumber { get; set; }
        public DateTime DateReg { get; set; }
        public string? Desc { get; set; }
        public int Identity { get; set; }
        public byte Idstate { get; set; }
        public string NameSubject { get; set; } = null!;
        public string CodeType { get; set; } = null!;
        public DateTime? DateChangeState { get; set; }
        public string? SerialNumber { get; set; }
        public int Idgroup { get; set; }
        public string GroupCode { get; set; } = null!;
        public bool GroupActive { get; set; }
        public string GroupKeyResource { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string? FirmName { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public int Idcountry { get; set; }
        public int? Idregion { get; set; }
        public string CountryCode { get; set; } = null!;
        public string? RegionName { get; set; }
        public int? Idorganisation { get; set; }
        public string? OrgName { get; set; }
        public short? TypeOrg { get; set; }
        public int? Idphoto { get; set; }
    }
}

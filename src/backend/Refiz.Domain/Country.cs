using System;
using System.Collections.Generic;
using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Domain
{
    public partial class Country
    {
        public Country()
        {
            Entities = new HashSet<Entity>();
            Organisations = new HashSet<Organisation>();
            Regions = new HashSet<Region>();
        }

        public int Idcountry { get; set; }
        public string CountryCode { get; set; } = null!;
        public byte Idlanguage { get; set; }

        public virtual Language IdlanguageNavigation { get; set; } = null!;
        public virtual ICollection<Entity> Entities { get; set; }
        public virtual ICollection<Organisation> Organisations { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}

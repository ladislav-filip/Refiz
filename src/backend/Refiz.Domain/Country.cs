using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Domain
{
    public class Country : DomainEntity
    {
        public int Id { get; set; }
        public string CountryCode { get; set; } = null!;
        public byte IdLanguage { get; set; }

        public virtual Language IdlanguageNavigation { get; set; } = null!;
        public virtual ICollection<Entity> Entities { get; set; } = new HashSet<Entity>();
        public virtual ICollection<Organisation> Organisations { get; set; } = new HashSet<Organisation>();
        public virtual ICollection<Region> Regions { get; set; } = new HashSet<Region>();
    }
}
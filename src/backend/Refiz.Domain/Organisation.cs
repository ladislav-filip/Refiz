using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Domain
{
    public partial class Organisation
    {
        public Organisation()
        {
            Entities = new HashSet<Entity>();
            Preparations = new HashSet<Preparation>();
        }

        public int Idorganisation { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public short TypeOrg { get; set; }
        public bool Active { get; set; }
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public int Idcountry { get; set; }
        public string? Phones { get; set; }
        public string Email { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateCreate { get; set; }
        public string SecureKey { get; set; } = null!;
        public bool WebApi { get; set; }
        public string? SwVersion { get; set; }
        public bool? AllowRestore { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public virtual Country IdcountryNavigation { get; set; } = null!;
        public virtual ICollection<Entity> Entities { get; set; }
        public virtual ICollection<Preparation> Preparations { get; set; }
    }
}

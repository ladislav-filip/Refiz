using Refiz.Domain.AggregatesModel.RegisterAggregate;

namespace Refiz.Domain.AggregatesModel.EntityAggregate
{
    public sealed class Entity : DomainEntity<int>, IAggregateRoot
    {
        public Entity()
        {
            EntitySettings = new HashSet<EntitySetting>();
            NotifyRecipients = new HashSet<NotifyRecipient>();
            Registers = new HashSet<Register>();
        }

        public Entity(Role role) : this()
        {
            Role = role;
        }
    
        public string NameEntity { get; set; } = null!;
        public string SurnameEntity { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string? Phone { get; set; }
        public string Email { get; set; } = null!;
        public int Idrole { get; set; }
        public bool IsFirm { get; set; }
        public string? FirmName { get; set; }
        public string? Cin { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreate { get; set; }
        public string Password { get; set; } = null!;
        public string? Zip { get; set; }
        public DateTime? DateActivated { get; set; }
        public int Idcountry { get; set; }
        public int? Idregion { get; set; }
        public int? Idorganisation { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Country Country { get; } = null!;
        public Organisation? Organisation { get; set; }
        public Region? Region { get; set; }
        public Role Role { get; } = null!;
        public ActivateEntity ActivateEntity { get; set; } = null!;
        public ICollection<EntitySetting> EntitySettings { get; set; }
        public ICollection<NotifyRecipient> NotifyRecipients { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}

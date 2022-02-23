using System;
using System.Collections.Generic;

namespace Scafold
{
    public partial class Entity
    {
        public Entity()
        {
            EntitySettings = new HashSet<EntitySetting>();
            Logs = new HashSet<Log>();
            NotifyRecipients = new HashSet<NotifyRecipient>();
            Registers = new HashSet<Register>();
        }

        public int Identity { get; set; }
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

        public virtual Country IdcountryNavigation { get; set; } = null!;
        public virtual Organisation? IdorganisationNavigation { get; set; }
        public virtual Region? IdregionNavigation { get; set; }
        public virtual Role IdroleNavigation { get; set; } = null!;
        public virtual ActivateEntity ActivateEntity { get; set; } = null!;
        public virtual ICollection<EntitySetting> EntitySettings { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<NotifyRecipient> NotifyRecipients { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
    }
}

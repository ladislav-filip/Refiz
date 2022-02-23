using System;
using System.Collections.Generic;

namespace Scafold
{
    public partial class NotifyRecipient
    {
        public int IdnotifyRecipient { get; set; }
        public int IdnotifySource { get; set; }
        public int Identity { get; set; }
        public bool AsEmail { get; set; }
        public bool AsSms { get; set; }
        public DateTime? LastDateNotified { get; set; }

        public virtual Entity IdentityNavigation { get; set; } = null!;
        public virtual NotifySource IdnotifySourceNavigation { get; set; } = null!;
    }
}

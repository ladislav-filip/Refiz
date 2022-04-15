namespace Scafold
{
    public partial class NotifySource
    {
        public NotifySource()
        {
            NotifyRecipients = new HashSet<NotifyRecipient>();
        }

        public int IdnotifySource { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<NotifyRecipient> NotifyRecipients { get; set; }
    }
}

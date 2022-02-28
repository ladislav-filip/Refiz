namespace Refiz.Domain.Views
{
    public partial class WNotifyRecipient
    {
        public int IdnotifyRecipient { get; set; }
        public int IdnotifySource { get; set; }
        public int Identity { get; set; }
        public bool AsEmail { get; set; }
        public bool AsSms { get; set; }
        public DateTime? LastDateNotified { get; set; }
        public string SourceName { get; set; } = null!;
        public bool SourceActive { get; set; }
        public bool EntityActive { get; set; }
        public string EntityEmail { get; set; } = null!;
    }
}

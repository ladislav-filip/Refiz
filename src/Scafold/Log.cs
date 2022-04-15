namespace Scafold
{
    public partial class Log
    {
        public Log()
        {
            RegisterHistories = new HashSet<RegisterHistory>();
        }

        public long Idlog { get; set; }
        public DateTime DateCreate { get; set; }
        public byte LogLevel { get; set; }
        public string? Event { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public string Msg { get; set; } = null!;
        public string? Data { get; set; }
        public int? Identity { get; set; }

        public virtual Entity? IdentityNavigation { get; set; }
        public virtual ICollection<RegisterHistory> RegisterHistories { get; set; }
    }
}

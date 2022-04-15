namespace Scafold
{
    public partial class Register
    {
        public Register()
        {
            Photos = new HashSet<Photo>();
            RegisterHistories = new HashSet<RegisterHistory>();
        }

        public int Idregister { get; set; }
        public string Code { get; set; } = null!;
        public DateTime DateReg { get; set; }
        public string? Desc { get; set; }
        public int Identity { get; set; }
        public byte Idstate { get; set; }
        public string NameSubject { get; set; } = null!;
        public string CodeType { get; set; } = null!;
        public int? RegNumber { get; set; }
        public DateTime? DateChangeState { get; set; }
        public string? SerialNumber { get; set; }
        public int Idgroup { get; set; }

        public virtual Entity IdentityNavigation { get; set; } = null!;
        public virtual Group IdgroupNavigation { get; set; } = null!;
        public virtual State IdstateNavigation { get; set; } = null!;
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<RegisterHistory> RegisterHistories { get; set; }
    }
}

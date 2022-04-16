namespace Refiz.Domain
{
    public class Language : DomainEntity
    {
        public Language()
        {
            Countries = new HashSet<Country>();
        }

        public byte Id { get; set; }
        public string Code { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}

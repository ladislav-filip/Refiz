namespace Refiz.Domain
{
    public class Language : DomainEntity<byte>
    {
        public Language()
        {
            Countries = new HashSet<Country>();
        }
        
        public string Code { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}

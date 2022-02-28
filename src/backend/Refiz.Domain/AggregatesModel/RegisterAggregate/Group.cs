namespace Refiz.Domain.AggregatesModel.RegisterAggregate
{
    public partial class Group
    {
        public Group()
        {
            Registers = new HashSet<Register>();
        }

        public int Idgroup { get; set; }
        public string Code { get; set; } = null!;
        public string KeyResource { get; set; } = null!;
        public bool Active { get; set; }
        public byte IndexOrder { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}

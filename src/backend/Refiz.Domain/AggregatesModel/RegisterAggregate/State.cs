namespace Refiz.Domain.AggregatesModel.RegisterAggregate
{
    public partial class State
    {
        public State()
        {
            Registers = new HashSet<Register>();
        }

        public byte Idstate { get; set; }
        public string NameState { get; set; } = null!;

        public virtual ICollection<Register> Registers { get; set; }
    }
}

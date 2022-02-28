namespace Refiz.Domain.AggregatesModel.RegisterAggregate
{
    public partial class RegisterHistory
    {
        public int IdregisterHistory { get; set; }
        public long Idlog { get; set; }
        public int Idregister { get; set; }

        public virtual Log IdlogNavigation { get; set; } = null!;
        public virtual Register IdregisterNavigation { get; set; } = null!;
    }
}

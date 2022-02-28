namespace Refiz.Domain.AggregatesModel.EntityAggregate
{
    public partial class EntitySetting
    {
        public int IdentitySetting { get; set; }
        public int Identity { get; set; }
        public string Key { get; set; } = null!;
        public string? Value { get; set; }

        public virtual Entity IdentityNavigation { get; set; } = null!;
    }
}

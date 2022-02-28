namespace Refiz.Domain.AggregatesModel.EntityAggregate
{
    public partial class ActivateEntity
    {
        public int IdactivateEntity { get; set; }
        public int Identity { get; set; }
        public DateTime DateExpired { get; set; }
        public string Code { get; set; } = null!;
        public DateTime DateCreate { get; set; }

        public virtual Entity IdentityNavigation { get; set; } = null!;
    }
}

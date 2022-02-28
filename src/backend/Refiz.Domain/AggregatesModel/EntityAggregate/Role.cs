namespace Refiz.Domain.AggregatesModel.EntityAggregate
{
    public partial class Role
    {
        public Role()
        {
            Entities = new HashSet<Entity>();
        }

        public int Idrole { get; set; }
        public string NameRole { get; set; } = null!;
        public string? Note { get; set; }

        public virtual ICollection<Entity> Entities { get; set; }
    }
}

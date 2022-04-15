using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Domain
{
    public partial class Region
    {
        public Region()
        {
            Entities = new HashSet<Entity>();
        }

        public int Idregion { get; set; }
        public int Idcountry { get; set; }
        public string RegionName { get; set; } = null!;

        public virtual Country IdcountryNavigation { get; set; } = null!;
        public virtual ICollection<Entity> Entities { get; set; }
    }
}

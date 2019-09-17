using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.LocationSource
{
    [Audited]
    public class LocationSource : FullAuditedEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public Enums.State State { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }


        public IList<Plastic.Plastic> Plastics { get; set; }

    }
}

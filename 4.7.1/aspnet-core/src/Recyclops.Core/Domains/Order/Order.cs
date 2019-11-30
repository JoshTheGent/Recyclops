using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Recyclops.Authorization.Users;

namespace Recyclops.Domains.Order
{
    [Audited]
    public class Order : FullAuditedEntity
    {
        #region Properties

        
        //Attributes
        public double TotalCost { get; set; }
        public bool IsComplete { get; set; }


        //relational
        public long ClientId { get; set; }


        //navigation
        public User Client { get; set; }
        public IList<PlasticOrder.PlasticOrder> PlasticOrders { get; set; }
        public IEnumerable<PrintableOrder.PrintableOrder> PrintableOrders { get; set; }
        #endregion

    }
}

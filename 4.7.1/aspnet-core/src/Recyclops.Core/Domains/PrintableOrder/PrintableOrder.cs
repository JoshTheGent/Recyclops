using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.PrintableOrder
{
    [Audited]
    public class PrintableOrder : FullAuditedEntity
    {
        #region Properties

        //Relational//
        public int PrintableObjectId { get; set; }
        public int OrderId { get; set; }




        //Navigational//
        //Has one
        public PrintableObject.PrintableObject PrintableObject { get; set; }
        //Has one
        public Order.Order Order { get; set; }



        #endregion
    }
}

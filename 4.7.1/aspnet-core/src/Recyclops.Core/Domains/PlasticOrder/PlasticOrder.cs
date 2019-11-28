using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.PlasticOrder
{
    [Audited]
    public class PlasticOrder : FullAuditedEntity
    {
        #region Properties

        //Attributes
        public double DerivedTotal { get; set; }





        //Relational
        public int PlasticSpoolId { get; set; }
        public int OrderId { get; set; }


        //Navigational
        //Has One
        public PlasticSpool.PlasticSpool PlasticSpool { get; set; }

        //Has One
        public Order.Order Order { get; set; }



        #endregion




    }
}

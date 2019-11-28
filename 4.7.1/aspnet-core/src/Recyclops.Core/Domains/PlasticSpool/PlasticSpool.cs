using System;
using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.PlasticSpool
{
    [Audited]
    public class PlasticSpool : FullAuditedEntity
    {
        #region Properties

        //Attributes
        public TimeSpan TimeToManufacture { get; set; }
        public int Mass { get; set; }
        public double ManufactureCost { get; set; }
        public double SellValue { get; set; }
        




        //Relational
        public int PlasticId { get; set; }


        //Navigational
        //Has One
        public Plastic.Plastic Plastic { get; set; }
        //Has Many
        public IList<PlasticOrder.PlasticOrder> PlasticOrders { get; set; }
        //Has Many
        public IList<PrintableObject.PrintableObject> PrintableObjects { get; set; }



        #endregion




    }
}

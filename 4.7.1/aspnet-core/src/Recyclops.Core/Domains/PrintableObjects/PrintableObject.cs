using System;
using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.PrintableObject
{
    [Audited]
    public class PrintableObject : FullAuditedEntity
    {
        #region Properties

        //Attributes
        public string Name { get; set; }
        public TimeSpan PrintTime { get; set; }
        public double PrintCost { get; set; }
        public double SellValue { get; set; }
        public string URL { get; set; }


        //remove to show ease of fixes
        //public double MassOfPrint { get; set; }


        //Relational
        public int PlasticSpoolId { get; set; }


        //Navigational
        //Has one
        public PlasticSpool.PlasticSpool PlasticSpool { get; set; }
        //Has Many
        public IList<PrintableOrder.PrintableOrder> PrintableOrders { get; set; }



        #endregion


    }
}

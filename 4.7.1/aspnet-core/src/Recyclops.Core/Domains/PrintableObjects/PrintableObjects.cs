using System;
using System.Collections.Generic;
using System.Text;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.PrintableObjects
{
    [Audited]
    public class PrintableObjects : FullAuditedEntity
    {
        #region Properties

        public string Name { get; set; }

        #endregion


    }
}

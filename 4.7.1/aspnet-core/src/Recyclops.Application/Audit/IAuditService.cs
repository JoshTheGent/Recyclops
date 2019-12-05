using System;
using System.Collections.Generic;
using System.Text;
using Recyclops.Audit.Dto;

namespace Recyclops.Audit
{
    public interface IAuditService
    {
        /// <summary>
        /// Gets audit information for changed data
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>AuditServiceDto</returns>
        List<AuditServiceDto> GetAuditTypeReport(DateTime start, DateTime end);
    }
}

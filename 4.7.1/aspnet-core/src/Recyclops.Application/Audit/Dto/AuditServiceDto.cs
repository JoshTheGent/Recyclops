using System;
using System.Collections.Generic;
using System.Text;
using Abp.Events.Bus.Entities;

namespace Recyclops.Audit.Dto
{
    public class AuditServiceDto
    {

        public AuditServiceDto(string user, string type, DateTime time, EntityChangeType changeType)
        {
            UsersName = user;
            Type = type;
            Date = time;
            switch (changeType)
            {
                case EntityChangeType.Created:
                    Reason = "Created";
                    break;
                case EntityChangeType.Updated:
                    Reason = "Updated";
                    break;
                case EntityChangeType.Deleted:
                    Reason = "Deleted";
                    break;
            }


            AuditDetails = new List<AuditDetailDto>();
        }

        public string UsersName { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Reason { get; set; }
        public List<AuditDetailDto> AuditDetails { get; set; }
    }



    public class AuditDetailDto
    {
        public AuditDetailDto(string propertyChanged, string originalValue, string newValue)
        {
            PropertyChanged = propertyChanged;
            OriginalValue = originalValue;
            NewValue = newValue;
        }

        public string PropertyChanged { get; set; }
        public string OriginalValue { get; set; }
        public string NewValue { get; set; }

    }
}

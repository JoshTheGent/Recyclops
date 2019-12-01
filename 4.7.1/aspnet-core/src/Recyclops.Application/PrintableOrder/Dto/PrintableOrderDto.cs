using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Recyclops.PrintableOrder.Dto
{
    [AutoMap(typeof(Domains.PrintableOrder.PrintableOrder))]
    public class PrintableOrderDto : EntityDto
    {
        public int PrintableObjectId { get; set; }
        public int OrderId { get; set; }
        public double DerivedTotal { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Recyclops.PlasticOrder.Dto
{
    [AutoMap(typeof(Domains.PlasticOrder.PlasticOrder))]
    public class PlasticOrderDto : EntityDto
    {
        public PlasticOrderDto()
        {

        }


        public int PlasticSpoolId { get; set; }
        public int OrderId { get; set; }
        public double DerivedTotal { get; set; }

        //Navigational
        //Has One
        public Domains.PlasticSpool.PlasticSpool PlasticSpool { get; set; }

        //Has One
        public Domains.Order.Order Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Recyclops.Domains.PlasticSpool;
using Recyclops.Domains.PrintableOrder;

namespace Recyclops.PrintableObject.Dto
{

    [AutoMap(typeof(Domains.PrintableObject.PrintableObject))]
    public class PrintableObjectDto : EntityDto
    {
        public PrintableObjectDto()
        {

        }

        public PrintableObjectDto(Domains.PrintableObject.PrintableObject dom)
        {
            Id = dom.Id;
            Name = dom.Name;
            PrintTime = dom.PrintTime;
            PrintCost = dom.PrintCost;
            SellValue = dom.SellValue;
            URL = dom.URL;
            PlasticSpoolId = dom.PlasticSpoolId;
            PlasticSpool = dom.PlasticSpool;
            PrintableOrders = dom.PrintableOrders;

        }


        //name of compound
        public string Name { get; set; }
        public TimeSpan PrintTime { get; set; }
        public double PrintCost { get; set; }
        public double SellValue { get; set; }
        public string URL { get; set; }

        //Relation
        public int PlasticSpoolId { get; set; }

        public Domains.PlasticSpool.PlasticSpool PlasticSpool { get; set; }
        //Has Many
        public IList<PrintableOrder> PrintableOrders { get; set; }


    }
}
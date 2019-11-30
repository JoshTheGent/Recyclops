using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Recyclops.PlasticSpool.Dto
{
    [AutoMap(typeof(Domains.PlasticSpool.PlasticSpool))]
    public class PlasticSpoolDto : EntityDto
    {

        public PlasticSpoolDto()
        {

        }

        public PlasticSpoolDto(Domains.PlasticSpool.PlasticSpool dom)
        {
            Id = dom.Id;
            TimeToManufacture = dom.TimeToManufacture;
            Mass = dom.Mass;
            ManufactureCost = dom.ManufactureCost;
            SellValue = dom.SellValue;
            PlasticId = dom.PlasticId;
            Plastic = dom.Plastic;
            PlasticOrders = dom.PlasticOrders;
            PrintableObjects = dom.PrintableObjects;

        }



        //Attributes
        public TimeSpan TimeToManufacture { get; set; }
        public int Mass { get; set; }
        public double ManufactureCost { get; set; }
        public double SellValue { get; set; }





        //Relational
        public int PlasticId { get; set; }


        //Navigational
        //Has One
        public Domains.Plastic.Plastic Plastic { get; set; }
        //Has Many
        public IList<Domains.PlasticOrder.PlasticOrder> PlasticOrders { get; set; }
        //Has Many
        public IList<Domains.PrintableObject.PrintableObject> PrintableObjects { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recyclops.PlasticSpool.Dto;

namespace Recyclops.Web.Models.PlasticSpool
{
    public class PlasticSpoolViewModel
    {


        public PlasticSpoolViewModel()
        {

        }

        public PlasticSpoolViewModel(PlasticSpoolDto dto)
        {

            Id = dto.Id;
            TimeToManufacture = dto.TimeToManufacture;
            Mass = dto.Mass;
            ManufactureCost = dto.ManufactureCost;
            SellValue = dto.SellValue;
            PlasticId = dto.PlasticId;

        }




        public int Id { get; set; }
        public TimeSpan TimeToManufacture { get; set; }
        public int Mass { get; set; }
        public double ManufactureCost { get; set; }
        public double SellValue { get; set; }
        public int PlasticId { get; set; }

        public PlasticSpoolDto DtoModel()
        {
            return new PlasticSpoolDto
            {
                Id = Id,
                TimeToManufacture = TimeToManufacture,
                Mass = Mass,
                ManufactureCost = ManufactureCost,
                SellValue = SellValue,
                PlasticId = PlasticId

            };
        }

    }
}

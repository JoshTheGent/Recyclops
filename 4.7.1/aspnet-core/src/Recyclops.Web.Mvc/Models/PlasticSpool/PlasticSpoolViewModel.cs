using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recyclops.Plastic.Dto;
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
            PlasticNameLoc = dto.Plastic.Name + " -- " + dto.Plastic.LocationSource.Name;

        }

        public PlasticSpoolViewModel(PlasticSpoolDto dto, IList<PlasticDto> plastics)
        {

            Id = dto.Id;
            TimeToManufacture = dto.TimeToManufacture;
            Mass = dto.Mass;
            ManufactureCost = dto.ManufactureCost;
            SellValue = dto.SellValue;
            PlasticId = dto.PlasticId;
            PlasticList = plastics.Select(x => new SelectListItem(x.Name + " -- " + x.LocationSource.Name, x.Id.ToString()));


        }

        public PlasticSpoolViewModel(IList<PlasticDto> plastics)
        {
            PlasticList = plastics.Select(x => new SelectListItem(x.Name + " -- " + x.LocationSource.Name, x.Id.ToString()));

        }


        public int Id { get; set; }
        public TimeSpan TimeToManufacture { get; set; }
        public int Mass { get; set; }
        public double ManufactureCost { get; set; }
        public double SellValue { get; set; }
        public int PlasticId { get; set; }
        public string PlasticNameLoc { get; set; }
        public IEnumerable<SelectListItem> PlasticList { get; set; }


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

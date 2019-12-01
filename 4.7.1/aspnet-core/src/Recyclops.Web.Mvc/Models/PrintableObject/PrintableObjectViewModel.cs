using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject.Dto;

namespace Recyclops.Web.Models.PrintableObject
{
    public class PrintableObjectViewModel
    {

        public PrintableObjectViewModel()
        {

        }


        public PrintableObjectViewModel(IList<PlasticSpoolDto> spools)
        {
            SpoolList = spools.Select(x => new SelectListItem(x.Mass + " -- " + x.Plastic.Name, x.Id.ToString()));
        }

        public PrintableObjectViewModel(PrintableObjectDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            PrintTime = dto.PrintTime;
            PrintCost = dto.PrintCost;
            SellValue = dto.SellValue;
            URL = dto.URL;
            PlasticSpoolId = dto.PlasticSpoolId;
            PlasticSpoolName = dto.PlasticSpool.Mass + " -- " + dto.PlasticSpool.Plastic.Name;
        }

        public PrintableObjectViewModel(PrintableObjectDto dto, IList<PlasticSpoolDto> spools)
        {

            Id = dto.Id;
            Name = dto.Name;
            PrintTime = dto.PrintTime;
            PrintCost = dto.PrintCost;
            SellValue = dto.SellValue;
            URL = dto.URL;
            PlasticSpoolId = dto.PlasticSpoolId;
            SpoolList = spools.Select(x => new SelectListItem(x.Mass + " -- " + x.Plastic.Name, x.Id.ToString()));

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan PrintTime { get; set; }
        public double PrintCost { get; set; }
        public double SellValue { get; set; }
        public string URL { get; set; }
        public int PlasticSpoolId { get; set; }
        public string PlasticSpoolName { get; set; }

        public IEnumerable<SelectListItem> SpoolList { get; set; }


        public PrintableObjectDto DtoModel()
        {
            return new PrintableObjectDto
            {
                Id = Id,
                Name = Name,
                PrintTime = PrintTime,
                PrintCost = PrintCost,
                SellValue = SellValue,
                URL = URL,
                PlasticSpoolId = PlasticSpoolId

            };
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abp.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recyclops.LocationSource.Dto;
using Recyclops.Plastic.Dto;

namespace Recyclops.Web.Models.Plastic
{
    public class PlasticViewModel
    {

        //empty constructor (also aids in serialization)
        public PlasticViewModel()
        {

        }
        
        //for grabbing the table
        public PlasticViewModel(PlasticDto dto)
        {

            Id = dto.Id;
            Name = dto.Name;
            Mass = dto.Mass;
            MeltingTemp = dto.MeltingTemp;
            HeatedBed = dto.HeatedBed;
            LocationSourceId = dto.LocationSourceId;
            LocationSource = dto.LocationSource;

        }

        //new modal
        public PlasticViewModel(IList<LocationSourceDto> locations)
        {
            LocationList = locations.Select(x => new SelectListItem(x.Name, x.Id.ToString()));

        }

        //edit modal
        public PlasticViewModel(PlasticDto dto, IList<LocationSourceDto> locations)
        {

            Id = dto.Id;
            Name = dto.Name;
            Mass = dto.Mass;
            MeltingTemp = dto.MeltingTemp;
            HeatedBed = dto.HeatedBed;
            LocationSourceId = dto.LocationSourceId;
            LocationList = locations.Select(x=> new SelectListItem(x.Name, x.Id.ToString()));

        }

        //Id of this object
        public int Id { get; set; }
        //name of compound
        public string Name { get; set; }
        //mass of plastic per gram
        public double Mass { get; set; }
        //melting temperature
        public double MeltingTemp { get; set; }
        //does this compound require a heated bed for printing
        public bool HeatedBed { get; set; }
        public int LocationSourceId { get; set; }

        //for selecting a location
        public IEnumerable<SelectListItem> LocationList { get; set; }

        //Relation for data, or table
        public Domains.LocationSource.LocationSource LocationSource { get; set; }

        //converting to Dto
        public PlasticDto DtoModel()
        {
            return new PlasticDto
            {
                Id = Id,
                Name = Name,
                Mass = Mass,
                MeltingTemp = MeltingTemp,
                HeatedBed = HeatedBed,
                LocationSourceId = LocationSourceId

            };
        }
    }
}

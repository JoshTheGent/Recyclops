using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Recyclops.Plastic.Dto
{

    [AutoMap(typeof(Domains.Plastic.Plastic))]
    public class PlasticDto : EntityDto
    {
        public PlasticDto()
        {

        }

        public PlasticDto(Domains.Plastic.Plastic dom)
        {
            Id = dom.Id;
            Name = dom.Name;
            Mass = dom.Mass;
            MeltingTemp = dom.MeltingTemp;
            HeatedBed = dom.HeatedBed;
            LocationSourceId = dom.LocationSourceId;
            LocationSource = dom.LocationSource;

        }


        //name of compound
        public string Name { get; set; }
        //mass of plastic per gram
        public double Mass { get; set; }
        //melting temperature
        public double MeltingTemp { get; set; }
        //does this compound require a heated bed for printing
        public bool HeatedBed { get; set; }
        
        //Relation
        public int LocationSourceId { get; set; }
        public Domains.LocationSource.LocationSource LocationSource { get; set; }


    }
}

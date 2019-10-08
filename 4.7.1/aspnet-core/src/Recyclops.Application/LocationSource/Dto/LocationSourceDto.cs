using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Recyclops.LocationSource.Dto
{
    [AutoMap(typeof(Domains.LocationSource.LocationSource))]
    public class LocationSourceDto : EntityDto
    {
        public LocationSourceDto() { }

        public LocationSourceDto(Domains.LocationSource.LocationSource dom)
        {
            Name = dom.Name;
            City = dom.City;
            State = dom.State;
            Address = dom.Address;
            Zip = dom.Zip;
            URL = dom.URL;
        }


        public string Name { get; set; }
        public string City { get; set; }
        public Enums.State State { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string URL { get; set; }
    }
}

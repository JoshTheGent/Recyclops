using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recyclops.LocationSource.Dto;

namespace Recyclops.Web.Models.LocationSource
{
    public class LocationSourceViewModel
    {
        public LocationSourceViewModel()
        {

        }

        public LocationSourceViewModel(LocationSourceDto dto)
        {

            Id = dto.Id;
            Name = dto.Name;
            City = dto.City;
            State = dto.State;
            Address = dto.Address;
            Zip = dto.Zip;
            URL = dto.URL;

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Enums.State State { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string URL { get; set; }


        public LocationSourceDto DtoModel()
        {
            return new LocationSourceDto
            {
                Id = Id,
                Name = Name,
                City = City,
                State = State,
                Address = Address,
                Zip = Zip,
                URL = URL

            };
        }
    }
}

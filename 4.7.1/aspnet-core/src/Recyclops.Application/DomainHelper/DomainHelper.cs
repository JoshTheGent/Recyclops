using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Recyclops.Domains.PlasticSpool;
using Recyclops.Domains.PrintableObject;
using Recyclops.LocationSource;
using Recyclops.LocationSource.Dto;
using Recyclops.Plastic;
using Recyclops.Plastic.Dto;
using Recyclops.PlasticSpool;
using Recyclops.PlasticSpool.Dto;
using Recyclops.PrintableObject;
using Recyclops.PrintableObject.Dto;

namespace Recyclops.DomainHelper
{
    public class DomainHelper : IDomainHelper, ITransientDependency
    {
        #region Properties

        private readonly IPlasticService _plasticRepository;
        private readonly ILocationSourceService _locationRepository;
        private readonly IPlasticSpoolService _spoolRepository;
        private readonly IPrintableObjectService _printableRepository;

        #endregion

        #region Constructor

        public DomainHelper(IPlasticService plasticRepository, ILocationSourceService locationRepository, IPlasticSpoolService spoolRepository, IPrintableObjectService printableRepository)
        {
            _plasticRepository = plasticRepository;
            _locationRepository = locationRepository;
            _spoolRepository = spoolRepository;
            _printableRepository = printableRepository;
        }


        #endregion


        #region Methods


        public void UploadLocations()
        {
            var locations = new List<Domains.LocationSource.LocationSource>();

            locations.Add(new Domains.LocationSource.LocationSource
            {
                Id = 0,
                Name = "Waste Management - Arlington Recycling Facility",
                City = "Arlington",
                Address = "1915 Merdian St",
                State = Enums.State.TX,
                Zip = "76011"
            });
            locations.Add(new Domains.LocationSource.LocationSource
            {
                Id = 0,
                Name = "DFW Recyclers",
                City = "Arlington",
                Address = "2410 w Division St",
                State = Enums.State.TX,
                Zip = "76012"
            });
            locations.Add(new Domains.LocationSource.LocationSource
            {
                Id = 0,
                Name = "Plastic Rescue",
                City = "Dallas",
                Address = "3323 Pluto St",
                State = Enums.State.TX,
                Zip = "75212",
                URL = "https://www.plasticrescue.com/"
            });

            locations.Select(x => _locationRepository.Create(new LocationSourceDto(x)));
        }


        public void UploadPlastics()
        {
            var plastics = new List<Domains.Plastic.Plastic>();

            plastics.Add(new Domains.Plastic.Plastic
            {

                CreationTime = DateTime.Now,
                Name = "PLA",
                Mass = 1.43,
                MeltingTemp = 180,
                HeatedBed = false,
                LocationSourceId = 3

            });
            plastics.Add(new Domains.Plastic.Plastic
            {

                CreationTime = DateTime.Now,
                Name = "PLA",
                Mass = 1.43,
                MeltingTemp = 180,
                HeatedBed = false,
                LocationSourceId = 2

            });
            plastics.Add(new Domains.Plastic.Plastic
            {

                CreationTime = DateTime.Now,
                Name = "ABS",
                Mass = 1.08,
                MeltingTemp = 240,
                HeatedBed = true,
                LocationSourceId = 2
            });
            plastics.Add(new Domains.Plastic.Plastic
            {

                CreationTime = DateTime.Now,
                Name = "ABS",
                Mass = 1.08,
                MeltingTemp = 240,
                HeatedBed = true,
                LocationSourceId = 3
            });
            plastics.Add(new Domains.Plastic.Plastic
            {

                CreationTime = DateTime.Now,
                Name = "Carbon Fiber Mix - ABS",
                Mass = 1.5,
                MeltingTemp = 230,
                HeatedBed = true,
                LocationSourceId = 1
            });
            plastics.Add(new Domains.Plastic.Plastic
            {

                CreationTime = DateTime.Now,
                Name = "PETG",
                Mass = 1.38,
                MeltingTemp = 230,
                HeatedBed = true,
                LocationSourceId = 1
            });
            plastics.Select(x => _plasticRepository.Create(new PlasticDto(x)));
        }

        public void UploadSpools()
        {
            var spools = new List<Domains.PlasticSpool.PlasticSpool>();
            spools.Add(new Domains.PlasticSpool.PlasticSpool
            {

                CreationTime = DateTime.Now,
                Mass = 1000,
                SellValue = 29.99,
                TimeToManufacture = new TimeSpan(15, 0, 0),
                ManufactureCost = 5.00,
                PlasticId = 1
            });
            spools.Add(new Domains.PlasticSpool.PlasticSpool
            {

                CreationTime = DateTime.Now,
                Mass = 1000,
                SellValue = 19.61,
                TimeToManufacture = new TimeSpan(23, 0, 0),
                ManufactureCost = 3.25,
                PlasticId = 3
            });
            spools.Add(new Domains.PlasticSpool.PlasticSpool
            {

                CreationTime = DateTime.Now,
                Mass = 1000,
                SellValue = 84.20,
                TimeToManufacture = new TimeSpan(23, 0, 0),
                ManufactureCost = 15.45,
                PlasticId = 5
            });
            spools.Add(new Domains.PlasticSpool.PlasticSpool
            {

                CreationTime = DateTime.Now,
                Mass = 1000,
                SellValue = 25,
                TimeToManufacture = new TimeSpan(10, 0, 0),
                ManufactureCost = 2.25,
                PlasticId = 6
            });
            spools.Select(x=> _spoolRepository.Create(new PlasticSpoolDto(x)));
        }


        public void UploadPrintables()
        {
            var printables = new List<Domains.PrintableObject.PrintableObject>();
            printables.Add(new Domains.PrintableObject.PrintableObject
            {

                CreationTime = DateTime.Now,
                Name = "Baby Groot",
                PrintCost = .5,
                PrintTime = new TimeSpan(8, 0, 0),
                SellValue = 5.00,
                URL = "https://www.thingiverse.com/thing:2014307",
                PlasticSpoolId = 1
            });
            printables.Select(x => _printableRepository.Create(new PrintableObjectDto(x)));
        }

        
        private int RandomInt()
        {
            var temp = new System.Random().Next(180, 260);

            return temp;

        }

        private bool RandomBool()
        {
            return new System.Random().Next(1, 10) % 2 == 0;
        }

        private string RandomName(int numLetters)
        {
            var result = "";
            for (var i = 0; i < numLetters; i++)
            {
                result += (char) new Random().Next(65, 90);
            }

            return result;
        }

        #endregion

    }
}

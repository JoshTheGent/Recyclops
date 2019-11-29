using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Recyclops.Domains.PlasticSpool;
using Recyclops.Domains.PrintableObject;

namespace Recyclops.DomainHelper
{
    public class DomainHelper : IDomainHelper, ITransientDependency
    {
        #region Properties

        private readonly IRepository<Domains.Plastic.Plastic> _plasticRepository;
        private readonly IRepository<Domains.LocationSource.LocationSource> _locationRepository;
        private readonly IRepository<PlasticSpool> _spoolRepository;
        private readonly IRepository<PrintableObject> _printableRepository;

        #endregion

        #region Constructor

        public DomainHelper(IRepository<Domains.Plastic.Plastic> plasticRepository, IRepository<Domains.LocationSource.LocationSource> locationRepository, IRepository<PlasticSpool> spoolRepository, IRepository<PrintableObject> printableRepository)
        {
            _plasticRepository = plasticRepository;
            _locationRepository = locationRepository;
            _spoolRepository = spoolRepository;
            _printableRepository = printableRepository;
        }


        #endregion


        #region Methods

        public void UploadData()
        { 
            if (!_plasticRepository.GetAll().Any() 
                && !_locationRepository.GetAll().Any()
                && !_spoolRepository.GetAll().Any()
                && !_printableRepository.GetAll().Any())
            {
                var locations = new List<Domains.LocationSource.LocationSource>();

                locations.Add(new Domains.LocationSource.LocationSource
                {
                    
                    CreationTime = DateTime.Now,
                    Name = "Waste Management - Arlington Recycling Facility",
                    City = "Arlington",
                    Address = "1915 Merdian St",
                    State = Enums.State.TX,
                    Zip = "76011"
                });
                locations.Add(new Domains.LocationSource.LocationSource
                {
                    
                    CreationTime = DateTime.Now,
                    Name = "DFW Recyclers",
                    City = "Arlington",
                    Address = "2410 w Division St",
                    State = Enums.State.TX,
                    Zip = "76012"
                });
                locations.Add(new Domains.LocationSource.LocationSource
                {
                    
                    CreationTime = DateTime.Now,
                    Name = "Plastic Rescue",
                    City = "Dallas",
                    Address = "3323 Pluto St",
                    State = Enums.State.TX,
                    Zip = "75212",
                    URL = "https://www.plasticrescue.com/"
                });

                foreach (var location in locations)
                {
                    _locationRepository.Insert(location);
                }

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
                foreach (var plastic in plastics)
                {
                    _plasticRepository.Insert(plastic);
                }


                var spools = new List<PlasticSpool>();
                spools.Add(new PlasticSpool
                {
                    
                    CreationTime = DateTime.Now,
                    Mass = 1000,
                    SellValue = 29.99,
                    TimeToManufacture = new TimeSpan(15,0,0),
                    ManufactureCost = 5.00,
                    PlasticId = 1
                });
                spools.Add(new PlasticSpool
                {
                    
                    CreationTime = DateTime.Now,
                    Mass = 1000,
                    SellValue = 19.61,
                    TimeToManufacture = new TimeSpan( 23, 0, 0),
                    ManufactureCost = 3.25,
                    PlasticId = 3
                });
                spools.Add(new PlasticSpool
                {
                    
                    CreationTime = DateTime.Now,
                    Mass = 1000,
                    SellValue = 84.20,
                    TimeToManufacture = new TimeSpan(23, 0, 0),
                    ManufactureCost = 15.45,
                    PlasticId = 5
                });
                spools.Add(new PlasticSpool
                {
                    
                    CreationTime = DateTime.Now,
                    Mass = 1000,
                    SellValue = 25,
                    TimeToManufacture = new TimeSpan(10, 0, 0),
                    ManufactureCost = 2.25,
                    PlasticId = 6
                });
                foreach (var spool in spools)
                {
                    _spoolRepository.Insert(spool);
                }

                var printables = new List<PrintableObject>();
                printables.Add(new PrintableObject
                {
                    
                    CreationTime = DateTime.Now,
                    Name = "Baby Groot",
                    PrintCost = .5,
                    PrintTime = new TimeSpan(8,0,0),
                    SellValue = 5.00,
                    URL = "https://www.thingiverse.com/thing:2014307"
                });

            }

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

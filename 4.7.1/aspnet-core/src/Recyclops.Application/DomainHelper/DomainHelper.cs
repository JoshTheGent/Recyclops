using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
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


        public async Task<List<int>> UploadLocations()
        {
            var locations = new List<Domains.LocationSource.LocationSource>
            {
                new Domains.LocationSource.LocationSource
                {
                    Id = 0,
                    Name = "Waste Management - Arlington Recycling Facility",
                    City = "Arlington",
                    Address = "1915 Merdian St",
                    State = Enums.State.TX,
                    Zip = "76011"
                },
                new Domains.LocationSource.LocationSource
                {
                    Id = 0,
                    Name = "DFW Recyclers",
                    City = "Arlington",
                    Address = "2410 w Division St",
                    State = Enums.State.TX,
                    Zip = "76012"
                },
                new Domains.LocationSource.LocationSource
                {
                    Id = 0,
                    Name = "Plastic Rescue",
                    City = "Dallas",
                    Address = "3323 Pluto St",
                    State = Enums.State.TX,
                    Zip = "75212",
                    URL = "https://www.plasticrescue.com/"
                }
            };

            var locIds = new List<int>();

            foreach (var location in locations)
            {
               locIds.Add((await _locationRepository.Create(new LocationSourceDto(location))).Id);
            }

            return locIds;


        }


        public async Task<List<int>> UploadPlastics(List<int> locIds)
        {
            var plastics = new List<Domains.Plastic.Plastic>
            {
                new Domains.Plastic.Plastic
                {
                    Id = 0,
                    Name = "PLA",
                    Mass = 1.43,
                    MeltingTemp = 180,
                    HeatedBed = false,
                    LocationSourceId = locIds[2]
                },
                new Domains.Plastic.Plastic
                {
                    Id = 0,
                    Name = "PLA",
                    Mass = 1.43,
                    MeltingTemp = 180,
                    HeatedBed = false,
                    LocationSourceId = locIds[1]
                },
                new Domains.Plastic.Plastic
                {
                    Id = 0,
                    Name = "ABS",
                    Mass = 1.08,
                    MeltingTemp = 240,
                    HeatedBed = true,
                    LocationSourceId = locIds[1]
                },
                new Domains.Plastic.Plastic
                {
                    Id = 0,
                    Name = "ABS",
                    Mass = 1.08,
                    MeltingTemp = 240,
                    HeatedBed = true,
                    LocationSourceId = locIds[2]
                },
                new Domains.Plastic.Plastic
                {
                    Id = 0,
                    Name = "Carbon Fiber Mix - ABS",
                    Mass = 1.5,
                    MeltingTemp = 230,
                    HeatedBed = true,
                    LocationSourceId = locIds[0]
                },
                new Domains.Plastic.Plastic
                {
                    Id = 0,
                    Name = "PETG",
                    Mass = 1.38,
                    MeltingTemp = 230,
                    HeatedBed = true,
                    LocationSourceId = locIds[0]
                }
            };

            var plasticIds = new List<int>();

            foreach (var plastic in plastics)
            {
                 plasticIds.Add((await _plasticRepository.Create(new PlasticDto(plastic))).Id);
            }

            return plasticIds;
        }

        public async Task<List<int>> UploadSpools(List<int> plasticIds)
        {
            var spools = new List<Domains.PlasticSpool.PlasticSpool>
            {
                new Domains.PlasticSpool.PlasticSpool
                {
                    Id = 0,
                    Mass = 1000,
                    SellValue = 29.99,
                    TimeToManufacture = new TimeSpan(15, 0, 0),
                    ManufactureCost = 5.00,
                    PlasticId = plasticIds[0]
                },
                new Domains.PlasticSpool.PlasticSpool
                {
                    Id = 0,
                    Mass = 1000,
                    SellValue = 19.61,
                    TimeToManufacture = new TimeSpan(23, 0, 0),
                    ManufactureCost = 3.25,
                    PlasticId = plasticIds[2]
                },
                new Domains.PlasticSpool.PlasticSpool
                {
                    Id = 0,
                    Mass = 1000,
                    SellValue = 84.20,
                    TimeToManufacture = new TimeSpan(23, 0, 0),
                    ManufactureCost = 15.45,
                    PlasticId = plasticIds[4]
                },
                new Domains.PlasticSpool.PlasticSpool
                {
                    Id = 0,
                    Mass = 1000,
                    SellValue = 25,
                    TimeToManufacture = new TimeSpan(10, 0, 0),
                    ManufactureCost = 2.25,
                    PlasticId = plasticIds[5]
                }
            };
            var spoolIds = new List<int>();
            foreach (var spool in spools)
            {
               spoolIds.Add((await _spoolRepository.Create(new PlasticSpoolDto(spool))).Id);
            }

            return spoolIds;
        }


        public async Task<List<int>> UploadPrintables(List<int> spoolIds)
        {
            var printables = new List<Domains.PrintableObject.PrintableObject>
            {
                new Domains.PrintableObject.PrintableObject
                {
                    Id = 0,
                    Name = "Baby Groot",
                    PrintCost = .5,
                    PrintTime = new TimeSpan(8, 0, 0),
                    SellValue = 5.00,
                    URL = "https://www.thingiverse.com/thing:2014307",
                    PlasticSpoolId = spoolIds[0]
                }
            };
            var printableIds = new List<int>();
            foreach (var printable in printables)
            {
                printableIds.Add((await _printableRepository.Create(new PrintableObjectDto(printable))).Id);
            }

            return printableIds;
        }


        public bool UploadCheck()
        {
            return (_locationRepository.GetAll(new PagedAndSortedResultRequestDto()).Result.TotalCount == 0)
                   && (_plasticRepository.GetAll(new PagedAndSortedResultRequestDto()).Result.TotalCount == 0)
                   && (_spoolRepository.GetAll(new PagedAndSortedResultRequestDto()).Result.TotalCount == 0)
                   && (_printableRepository.GetAll(new PagedAndSortedResultRequestDto()).Result.TotalCount == 0);



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

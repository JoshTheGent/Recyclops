using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;

namespace Recyclops.DomainHelper
{
    public class DomainHelper : IDomainHelper, ITransientDependency
    {
        #region Properties

        private readonly IRepository<Domains.Plastic.Plastic> _plasticRepository;


        #endregion

        #region Constructor

        public DomainHelper(IRepository<Domains.Plastic.Plastic> plasticRepository)
        {
            _plasticRepository = plasticRepository;

        }


        #endregion


        #region Methods

        public async Task UploadData()
        {
            var plastics = new List<Domains.Plastic.Plastic>();
            for (var i = 0; i < 20; i = 0)
            {
                var plastic = new Domains.Plastic.Plastic
                {
                    Id = 0,
                    CreationTime = DateTime.Now,
                    MeltingTemp = (double) RandomInt(),
                    HeatedBed = RandomBool(),
                    Name = RandomName(3),
                   

                };
            }

            _plasticRepository.Insert()


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

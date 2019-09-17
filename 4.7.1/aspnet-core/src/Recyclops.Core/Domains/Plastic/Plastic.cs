using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Recyclops.Domains.Plastic
{
    [Audited]
    public class Plastic : FullAuditedEntity    
    {

        #region Properties

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

        //Navigation
        public LocationSource.LocationSource LocationSource { get; set; }


        #endregion



    }
}

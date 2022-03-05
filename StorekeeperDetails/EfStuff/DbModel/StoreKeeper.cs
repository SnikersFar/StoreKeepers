using System.Collections.Generic;

namespace StorekeeperDetails.EfStuff.DbModel
{
    public class StoreKeeper : BaseModel
    {
        public string Name { get; set; }
        public virtual List<Detail> Details { get; set; }
    }
}
using System;

namespace StorekeeperDetails.EfStuff.DbModel
{
    public class Detail : BaseModel
    {
        public string NomenCode { get; set; }
        public string Name { get; set; }
        public long Count { get; set; }
        public virtual StoreKeeper Keeper { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}

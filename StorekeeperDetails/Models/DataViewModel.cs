using System.Collections.Generic;

namespace StorekeeperDetails.Models
{
    public class DataViewModel
    {
        public List<StoreKeeperViewModel> Keepers { get; set; }
        public List<DetailViewModel> Details { get; set; }
    }
}

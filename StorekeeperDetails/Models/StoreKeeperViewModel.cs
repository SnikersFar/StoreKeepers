using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StorekeeperDetails.Models
{
    public class StoreKeeperViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please write Full Name!")]
        public string Name { get; set; }
        public List<DetailViewModel> Details { get; set; }
    }
}

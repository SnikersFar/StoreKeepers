using System;
using System.ComponentModel.DataAnnotations;

namespace StorekeeperDetails.Models
{
    public class DetailViewModel
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please write NomenCode!")]
        public string NomenCode { get; set; }
        [Required(ErrorMessage = "Please write Name!")]
        public string Name { get; set; }
        public long Count { get; set; }
        [Required(ErrorMessage = "Please Choose Keeper")]
        public long KeeperId { get; set; }
        public string KeeperName { get; set; }
        [Required(ErrorMessage = "Please chose date of created")]
        public DateTime DateCreated { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}

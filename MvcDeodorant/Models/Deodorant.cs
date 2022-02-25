using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcDeodorant.Models
{
    public class Deodorant
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Expired Date")]
        [DataType(DataType.Date)]
        public DateTime ExpiredDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Fragrance { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string  Type { get; set; }

        [StringLength(1)]
        [Required]
        public string Rating { get; set; }

    }
}
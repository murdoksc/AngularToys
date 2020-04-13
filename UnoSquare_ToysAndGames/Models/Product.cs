using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace UnoSquare_ToysAndGames.Models
{
    public class Product : BaseEntity
    {
        //Code First Approach, creating the model 

        [Required]
        [MaxLength]
        public string Name { get; set; }


        [MaxLength(100)]
        public string Description { get; set; }

        //this field is optional in requirements but also has 0 to 100 as constrains
        //[Range(0, 100)]
        public int? AgeRestriction { get; set; }


        [Required]
        [MaxLength(50)]
        public string Company { get; set; }

        [Required]
        [Range(1, 1000)]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

    }
}

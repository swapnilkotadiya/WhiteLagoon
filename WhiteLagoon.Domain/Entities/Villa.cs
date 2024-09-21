using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }

        [MaxLength(60)]
        public required string Name { get; set; }   

        public string? Description { get; set; }

        [Display(Name = "Price Per Night")]
        [Range(10,10000)]
        public double Price { get; set; }  

        public int Sqft { get; set; }

        [Range(1,10)]
        public int Occupancy { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}

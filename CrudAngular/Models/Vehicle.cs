using CrudAngular.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAngular.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public int ModelId { get; set; }

        public Model Model {get; set; }

        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(225)]
        public string ContactName { get; set; }

        [StringLength(225)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(225)]
        public string ContactPhone { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<VehicleFeature> Features { get; set; }


        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();

        }
    }
}

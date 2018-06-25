using CrudAngular.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAngular.Controllers.Resources
{
    public class VehicleFeature
    {
        [Key]
        public int VehicleId { get; set; }

        public int FeatureId { get; set; }

        public Vehicle Vehicle { get; set; }

        public Feature Feature { get; set; }

    }
}

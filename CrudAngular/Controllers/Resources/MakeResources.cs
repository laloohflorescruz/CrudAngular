using CrudAngular.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAngular.Controllers.Resources
{
    public class MakeResources
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ModelResource> Models { get; set; }

        public MakeResources()
        {
            Models = new Collection<ModelResource>();
        }
    }
}

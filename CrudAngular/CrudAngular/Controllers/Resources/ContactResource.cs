using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAngular.Controllers.Resources
{
    public class ContactResource
    {
        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        [StringLength(225)]
        public string Email { get; set; }

        [Required]
        [StringLength(225)]
        public string Phone { get; set; }
    }
}

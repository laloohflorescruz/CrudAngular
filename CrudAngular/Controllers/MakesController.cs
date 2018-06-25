using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CrudAngular.Controllers.Resources;
using CrudAngular.Data;
using CrudAngular.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudAngular.Controllers
{
    [EnableCors("CORSPolicy")]
    [Route("/api/makes")]

    public class MakesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MakesController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MakeResources>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();
            return mapper.Map<List<Make>, List<MakeResources>>(makes);
        }
    }
}
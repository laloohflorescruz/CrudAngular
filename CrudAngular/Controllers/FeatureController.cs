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
    public class FeatureController : Controller
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;


        public FeatureController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }


        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResources>> GetFeatures()
        {
            var features = await context.Features.ToListAsync();
            return mapper.Map<List<Feature>, List<FeatureResources>>(features);
        }
    }
}
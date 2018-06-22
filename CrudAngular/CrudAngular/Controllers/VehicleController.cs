using AutoMapper;
using CrudAngular.Controllers.Resources;
using CrudAngular.Data;
using CrudAngular.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CrudAngular.Controllers
{

    [EnableCors("CORSPolicy")]
    //[Route("/api/vehicles")]

    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VehicleController(ApplicationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [Route("/api/vehicles/create")]
        //[HttpGet]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            /*  var model = await context.Models.FindAsync(vehicleResource.ModelId);
              if (model == null)
              {
                  ModelState.AddModelError("ModelId", "Invalid modelId");
                  return BadRequest(ModelState);

              } */

            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var results = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(results);
        }



        //[HttpPut("{id}")]
        [Route("/api/vehicles/{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await context.Vehicles.Include(v=>v.Features).SingleOrDefaultAsync(v=>v.Id == id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle );
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();

            var results = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(results);
        }


        //[HttpDelete("{id}")]
        [Route("/api/vehicles/{id}")]
        public async Task<IActionResult> DeleteVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();
            
            context.Remove(vehicle);
            await context.SaveChangesAsync();
            return Ok(id); 
        }


        //[HttpGet]
        [Route("get/{id}")]

        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles.Include(v=>v.Features). SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(vehicleResource);
        }
    }
}
 
using FlightManagement.Model.Flight;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : BaseController
    {
        private IFlightServices _flightServices;
        public FlightController(IFlightServices flightServices)
        {
            _flightServices = flightServices;
        }

        [HttpPost]
        public async Task<FlightCreateRespone> Create(FlightCreateRequest flightCreateRequest)
        {
            return await _flightServices.CreateFlight(flightCreateRequest);
        }
        [HttpGet]
        public async Task<IEnumerable<FlightGetRespone>> GetAll()
        {
            return await _flightServices.GetAll();
        }
        [HttpGet("{Id}")]
        public async Task<FlightGetRespone> GetById(int id)
        {
            return await _flightServices.GetById(id);
        }
        [HttpPut("{Id}")]
        public async Task<FlightUpdateRespone> Update(int id,FlightUpdateRequest flightUpdateRequest)
        {
            return await _flightServices.UpdateFlight(id,flightUpdateRequest);
        }
        [HttpDelete("{Id}")]
        public async Task<bool> Delete(int id)
        {
            return await _flightServices.DeleteFlight(id);
        }
        [HttpPost("{FlightByAirport}")]
        public async Task<IEnumerable<FlightGetRespone>> GetFlightByAirport(FlightByAirportRequest flightByAirportRequest)
        {
            return await _flightServices.GetFlightByAirport(flightByAirportRequest);
        }
    }
}

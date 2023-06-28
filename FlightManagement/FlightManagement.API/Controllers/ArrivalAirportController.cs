using FlightManagement.Model.ArrivalAirport;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalAirportController : ControllerBase
    {
        private IArrivalAirportServices _arrivalAirportServices;
        public ArrivalAirportController(IArrivalAirportServices arrivalAirportServices)
        {
            _arrivalAirportServices = arrivalAirportServices;
        }
        [HttpPost]
        public async Task<ArrivalAirportCreateRespone>Create(ArrivalAirportCreateRequest arrivalAirportCreateRequest)
        {
            return await _arrivalAirportServices.CreateArrivalAirport(arrivalAirportCreateRequest);
        }
        [HttpGet]
        public async Task<IEnumerable<ArrivalAirportGetRespone>> GetAll()
        {
            return await _arrivalAirportServices.GetAll();
        }

        [HttpGet("{Id}")]
        public async Task<ArrivalAirportGetRespone> GetById(int id)
        {
            return await _arrivalAirportServices.GetById(id);
        }
        [HttpPut("{Id}")]
        public async Task<ArrivalAirportUpdateRespone>Update (int id,ArrivalAirportUpdateRequest arrivalAirportUpdateRequest)
        {
            return await _arrivalAirportServices.UpdateArrivalAirport (id,arrivalAirportUpdateRequest);
        }

        [HttpDelete("{Id}")]
        public async Task<bool>Delete(int id)
        {
            return await _arrivalAirportServices.DeleteArrivalAirport(id);
        }
    }
}

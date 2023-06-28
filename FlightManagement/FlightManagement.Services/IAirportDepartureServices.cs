using FlightManagement.Model.AirportDeparture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IAirportDepartureServices
    {
        Task<List<AirportDepartureGetRespone>> GetAll();
        Task<AirportDepartureGetRespone> GetById(int Id);
        Task<AirportDepartureUpdateRespone> UpdateAirportDeparture(int Id,AirportDepartureUpdateRequest airportDepartureUpdateRequest);
        Task<AirportDepartureCreateRespone> CreateAirportDeparture(AirportDepartureCreateRequest airportDepartureCreateRequest);
        Task<bool> DeleteAirportDeparture(int Id);
    }
}

using FlightManagement.Model.ArrivalAirport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IArrivalAirportServices
    {
        Task<List<ArrivalAirportGetRespone>> GetAll();
        Task<ArrivalAirportGetRespone> GetById(int id);
        Task<ArrivalAirportCreateRespone> CreateArrivalAirport(ArrivalAirportCreateRequest arrivalAirportCreateRequest );
        Task<ArrivalAirportUpdateRespone> UpdateArrivalAirport(int id, ArrivalAirportUpdateRequest arrivalAirportUpdateRequest);
        Task<bool> DeleteArrivalAirport(int id);

    }
}

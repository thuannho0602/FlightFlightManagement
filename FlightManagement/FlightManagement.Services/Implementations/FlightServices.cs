using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.Flight;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class FlightServices : IFlightServices
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ApplicationDbContext _appDbContext;

        public FlightServices(IFlightRepository flightRepository, ApplicationDbContext appDbContext)
        {
            _flightRepository = flightRepository;
            _appDbContext = appDbContext;
        }

        public async Task<FlightCreateRespone> CreateFlight(FlightCreateRequest flightCreateRequest)
        {
            if (flightCreateRequest.Id == 0)
            {
                var flight = new Flight
                {
                    DepartureTime = TimeSpan.Parse(flightCreateRequest.DepartureTime),
                    Price = flightCreateRequest.Price,
                    Time = flightCreateRequest.Time,
                    PlaneId = flightCreateRequest.PlaneId,
                    AirportDepartureId = flightCreateRequest.AirportDepartureId,
                    ArrivalAirportId = flightCreateRequest.ArrivalAirportId,
                };
                _flightRepository.Add(flight);
                _flightRepository.SaveChanges();

                var flightRepone = new FlightCreateRespone
                {
                    Id = flight.Id,
                    DepartureTime = flight.DepartureTime.ToString("hh\\:mm"),
                    Price = flight.Price,
                    Time = flight.Time,
                    PlaneID = flight.PlaneId,
                    NamePlane = _appDbContext.Planes.Where(x => x.Id == flight.PlaneId).FirstOrDefault().NamePlane,
                    ArrivalAirportID = flight.ArrivalAirportId,
                    NameArrivalAirport=_appDbContext.ArrivalAirports.Where(x=>x.Id==flight.ArrivalAirportId).FirstOrDefault().NameArrivalAirport,
                    AirportDepartureID = flight.AirportDepartureId,
                    NameAirportDeparture=_appDbContext.AirportDepartures.Where(x=>x.Id==flight.AirportDepartureId).FirstOrDefault().NameAirportDeparture,

                };
                return await Task.FromResult(flightRepone);
            }
            else
            {
                return new FlightCreateRespone();
            }
        }

        public async Task<bool> DeleteFlight(int id)
        {
            var flight=_flightRepository.FindByCondition(c=>c.Id==id).FirstOrDefault();
            if (flight != null)
            {
                _flightRepository.Remove(flight);
                _flightRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<FlightGetRespone>> GetAll()
        {
            var listFlight = _flightRepository.FindAll().Select(c => new FlightGetRespone
            {
                Id = c.Id,
                Price = c.Price,
                DepartureTime = c.DepartureTime.ToString("hh\\:mm"),
                Time = c.Time,
                PlaneID = c.PlaneId,
                NamePlane = _appDbContext.Planes.Where(x => x.Id == c.PlaneId).FirstOrDefault().NamePlane,
                ArrivalAirportID = c.ArrivalAirportId,
                NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == c.ArrivalAirportId).FirstOrDefault().NameArrivalAirport,
                AirportDepartureID = c.AirportDepartureId,
                NameAirportDeparture = _appDbContext.AirportDepartures.Where(x => x.Id == c.AirportDepartureId).FirstOrDefault().NameAirportDeparture,

            }).ToList();
            return await Task.FromResult(listFlight);
        }

        public async Task<FlightGetRespone> GetById(int id)
        {
            var flight = _flightRepository.FindByCondition(c => c.Id == id).Select(c => new FlightGetRespone
            {
                Id = c.Id,
                Price = c.Price,
                DepartureTime = c.DepartureTime.ToString("hh\\:mm"),
                Time = c.Time,
                PlaneID = c.PlaneId,
                NamePlane = _appDbContext.Planes.Where(x => x.Id == c.PlaneId).FirstOrDefault().NamePlane,
                ArrivalAirportID = c.ArrivalAirportId,
                NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == c.ArrivalAirportId).FirstOrDefault().NameArrivalAirport,
                AirportDepartureID = c.AirportDepartureId,
                NameAirportDeparture = _appDbContext.AirportDepartures.Where(x => x.Id == c.AirportDepartureId).FirstOrDefault().NameAirportDeparture,
            }).FirstOrDefault();
            return await Task.FromResult(flight);
        }

        public async Task<List<FlightGetRespone>> GetFlightByAirport(FlightByAirportRequest flightByAirportRequest)
        {
            var listflight=_flightRepository.FindByCondition(c=>c.ArrivalAirportId==flightByAirportRequest.ArrivalAirportID
            && c.AirportDepartureId==flightByAirportRequest.ArrivalAirportID).Select(c=>new FlightGetRespone
            {
                Id = c.Id,
                Price = c.Price,
                DepartureTime = c.DepartureTime.ToString("hh\\:mm"),
                Time = c.Time,
                PlaneID = c.PlaneId,
                NamePlane = _appDbContext.Planes.Where(x => x.Id == c.PlaneId).FirstOrDefault().NamePlane,
                ArrivalAirportID = c.ArrivalAirportId,
                NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == c.PlaneId).FirstOrDefault().NameArrivalAirport,
                AirportDepartureID = c.AirportDepartureId,
                NameAirportDeparture = _appDbContext.ArrivalAirports.Where(x => x.Id == c.AirportDepartureId).FirstOrDefault().NameArrivalAirport,
            }).ToList();
            return await Task.FromResult(listflight);

        }

        public async Task<FlightUpdateRespone> UpdateFlight(int id, FlightUpdateRequest flightUpdateRequest)
        {
            var flight=_flightRepository.FindByCondition(c=>c.Id==id).FirstOrDefault();
            if (flight != null)
            {
                flight = new Flight
                {
                    Id = id,
                    DepartureTime = TimeSpan.Parse(flightUpdateRequest.DepartureTime),
                    Price = flightUpdateRequest.Price,
                    Time = flightUpdateRequest.Time,
                    PlaneId = flightUpdateRequest.PlaneID,
                    ArrivalAirportId = flightUpdateRequest.ArrivalAirportID,
                    AirportDepartureId = flightUpdateRequest.AirportDepartureID,
                };
                _flightRepository.Update(flight);
                _flightRepository.SaveChanges();

                var flightRespone = new FlightUpdateRespone
                {
                    Id = flight.Id,
                    DepartureTime = flight.DepartureTime.ToString("hh\\:mm"),
                    Price = flight.Price,
                    Time = flight.Time,
                    PlaneID = flight.PlaneId,
                    NamePlane = _appDbContext.Planes.Where(x => x.Id == flight.PlaneId).FirstOrDefault().NamePlane,
                    ArrivalAirportID = flight.AirportDepartureId,
                    NameArrivalAirport = _appDbContext.ArrivalAirports.Where(x => x.Id == flight.ArrivalAirportId).FirstOrDefault().NameArrivalAirport,
                    AirportDepartureID = flight.AirportDepartureId,
                    NameAirportDeparture = _appDbContext.AirportDepartures.Where(x => x.Id == flight.AirportDepartureId).FirstOrDefault().NameAirportDeparture,
                };
                return await Task.FromResult(flightRespone);
            }
            else
            {
                return new FlightUpdateRespone();
            }
        }
    }
}

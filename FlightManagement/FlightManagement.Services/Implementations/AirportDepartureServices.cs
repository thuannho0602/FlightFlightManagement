using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.AirportDeparture;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class AirportDepartureServices : IAirportDepartureServices
    {
        private readonly IAirportDepartureRepository _airportDepartureRepository;
        private readonly ApplicationDbContext _appDbContext;
        public AirportDepartureServices(IAirportDepartureRepository airportDepartureRepository, ApplicationDbContext appDbContext)
        {
            _airportDepartureRepository = airportDepartureRepository;
            _appDbContext = appDbContext;
        }

        public async Task<AirportDepartureCreateRespone> CreateAirportDeparture(AirportDepartureCreateRequest airportDepartureCreateRequest)
        {
            if(airportDepartureCreateRequest.Id == 0)
            {
                var airportDeparture = new AirportDeparture
                {
                    Code = airportDepartureCreateRequest.Code,
                    NameAirportDeparture = airportDepartureCreateRequest.NameAirportDeparture
                };
                _airportDepartureRepository.Add(airportDeparture);
                _airportDepartureRepository.SaveChanges();

                var airportDepartureRespone = new AirportDepartureCreateRespone
                {
                    Id = airportDeparture.Id,
                    Code = airportDeparture.Code,
                    NameAirportDeparture = airportDeparture.NameAirportDeparture,
                };
                return await Task.FromResult(airportDepartureRespone);
                
            }
            else
            {
                return new AirportDepartureCreateRespone();
            }
        }

        public async Task<bool> DeleteAirportDeparture(int Id)
        {
            var airportDeparture = _airportDepartureRepository.FindByCondition(c => c.Id == Id).FirstOrDefault();
            if(airportDeparture!=null)
            {
                _airportDepartureRepository.Remove(airportDeparture);
                _airportDepartureRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        public async Task<List<AirportDepartureGetRespone>> GetAll()
        {
            var listairportDeparture = _airportDepartureRepository.FindAll().Select(c => new AirportDepartureGetRespone
            {
                Id = c.Id,
                Code = c.Code,
                NameAirportDeparture = c.NameAirportDeparture

            }).ToList();
           return await Task.FromResult(listairportDeparture);
        }

        public async Task<AirportDepartureGetRespone> GetById(int Id)
        {
           var airportDeparture=_airportDepartureRepository.FindByCondition(c=>c.Id == Id).Select(c=>new AirportDepartureGetRespone
           {
               Id=c.Id,
               Code=c.Code,
               NameAirportDeparture=c.NameAirportDeparture
           }).FirstOrDefault();
            return await Task.FromResult(airportDeparture);
        }

        public async Task<AirportDepartureUpdateRespone> UpdateAirportDeparture(int Id, AirportDepartureUpdateRequest airportDepartureUpdateRequest)
        {
            if (Id > 0)
            {
                var airportDeparture=_airportDepartureRepository.FindByCondition(c=>c.Id==Id).FirstOrDefault();
                if(airportDeparture != null)
                {
                    var airportDepartureModel = new AirportDeparture
                    {
                        Id = Id,
                        Code = airportDepartureUpdateRequest.Code,
                        NameAirportDeparture = airportDepartureUpdateRequest.NameAirportDeparture,
                    };
                    _airportDepartureRepository.Update(airportDepartureModel);
                    _airportDepartureRepository.SaveChanges();

                    var airportDepartureRespone = new AirportDepartureUpdateRespone
                    {
                        Id = airportDepartureModel.Id,
                        Code = airportDepartureModel.Code,
                        NameAirportDeparture = airportDepartureModel.NameAirportDeparture,
                    };
                    return await Task.FromResult(airportDepartureRespone);
                }
                return new AirportDepartureUpdateRespone();
            }
            else
            {
                return new AirportDepartureUpdateRespone();
            }
        }
    }
}

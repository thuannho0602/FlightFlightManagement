using FlightManagement.DataAccess;
using FlightManagement.Entity;
using FlightManagement.Model.ArrivalAirport;
using FlightManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services.Implementations
{
    public class ArrivalAirportServices : IArrivalAirportServices
    {
        private readonly IArrivalAirportRepository _arrivalAirportRepository;
        private readonly ApplicationDbContext _appDbContext;
        public ArrivalAirportServices(IArrivalAirportRepository arrivalAirportRepository, ApplicationDbContext appDbContext)
        {
            _arrivalAirportRepository = arrivalAirportRepository;
            _appDbContext = appDbContext;
        }

        public async Task<ArrivalAirportCreateRespone> CreateArrivalAirport(ArrivalAirportCreateRequest arrivalAirportCreateRequest)
        {
            if (arrivalAirportCreateRequest.Id == 0)
            {
                var arrivalAirport = new ArrivalAirport
                {
                    Code = arrivalAirportCreateRequest.Code,
                    NameArrivalAirport = arrivalAirportCreateRequest.NameArrivalAirport,
                };
                _arrivalAirportRepository.Add(arrivalAirport);
                _arrivalAirportRepository.SaveChanges();
                var arrivalAirportRespone = new ArrivalAirportCreateRespone
                {
                    Id = arrivalAirport.Id,
                    Code = arrivalAirport.Code,
                    NameArrivalAirport = arrivalAirport.NameArrivalAirport,
                };
                return await Task.FromResult(arrivalAirportRespone);
            }
            else
            {
                return new ArrivalAirportCreateRespone();
            }
        }

        public async Task<bool> DeleteArrivalAirport(int id)
        {
            var arrivalAirport=_arrivalAirportRepository.FindByCondition(c=>c.Id==id).FirstOrDefault();
            if (arrivalAirport != null)
            {
                _arrivalAirportRepository.Remove(arrivalAirport);
                _arrivalAirportRepository.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);

        }

        public async Task<List<ArrivalAirportGetRespone>> GetAll()
        {
            var listarrivalAirport = _arrivalAirportRepository.FindAll().Select(c => new ArrivalAirportGetRespone
            {
                Id = c.Id,
                Code = c.Code,
                NameArrivalAirport = c.NameArrivalAirport,
            }).ToList();
            return await Task.FromResult(listarrivalAirport);
        }

        public async Task<ArrivalAirportGetRespone> GetById(int id)
        {
            var arrivalAirport = _arrivalAirportRepository.FindByCondition(c => c.Id == id).Select(c => new ArrivalAirportGetRespone
            {
                Id = c.Id,
                Code = c.Code,
                NameArrivalAirport = c.NameArrivalAirport,
            }).FirstOrDefault();
            return await Task.FromResult(arrivalAirport);
        }

        public async Task<ArrivalAirportUpdateRespone> UpdateArrivalAirport(int id, ArrivalAirportUpdateRequest arrivalAirportUpdateRequest)
        {
            if (id > 0)
            {
                var arrivalAirport=_arrivalAirportRepository.FindByCondition(c=>c.Id==id).FirstOrDefault();
                if (arrivalAirport != null)
                {
                    var arrivalAirportModel = new ArrivalAirport
                    {
                        Id = id,
                        Code = arrivalAirportUpdateRequest.Code,
                        NameArrivalAirport = arrivalAirportUpdateRequest.NameArrivalAirport,
                    };
                    _arrivalAirportRepository.Update(arrivalAirportModel);
                    _arrivalAirportRepository.SaveChanges();
                    var arrivalAirportRepone = new ArrivalAirportUpdateRespone
                    {
                        Id = arrivalAirportModel.Id,
                        Code = arrivalAirportModel.Code,
                        NameArrivalAirport = arrivalAirportModel.NameArrivalAirport,
                    };
                    return await Task.FromResult(arrivalAirportRepone);
                }
                return new ArrivalAirportUpdateRespone();
            }
            else
            {
                return new ArrivalAirportUpdateRespone();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.Flight
{
    public class FlightCreateRequest
    {
        public int Id { get; set; }
        public string DepartureTime { get; set; }
        public int Time { get; set; }
        public decimal Price { get; set; }


        // Khóa Ngoại
        public int ArrivalAirportId { get; set; }
 
        public int AirportDepartureId { get; set; }
  
        public int PlaneId { get; set; }
        
    }
}

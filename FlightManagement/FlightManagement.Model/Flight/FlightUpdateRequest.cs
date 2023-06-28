﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.Flight
{
    public class FlightUpdateRequest
    {
        public int Id { get; set; }
        public string DepartureTime { get; set; }
        public int Time { get; set; }
        public decimal Price { get; set; }
        public int AirportDepartureID { get; set; }
        public int ArrivalAirportID { get; set; }
        public int PlaneID { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.AirportDeparture
{
    public class AirportDepartureGetRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameAirportDeparture { get; set; }
    }
}

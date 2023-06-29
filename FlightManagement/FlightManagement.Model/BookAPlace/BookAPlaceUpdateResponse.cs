﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.BookAPlace
{
    public class BookAPlaceUpdateResponse
    {
        public int Id { get; set; }
        public string CodePlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDay { get; set; }
        public int FlightID { get; set; }
        public string FlightName { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
    }
}

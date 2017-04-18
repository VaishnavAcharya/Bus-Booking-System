using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystem.Domain.Models
{
     public class AvailabilityDetails
    {
        public int Id { get; set; }
        public int?   BusDetailsId { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public bool IsReturn { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public BusDetails BusDetails { get; set; }
    }
}

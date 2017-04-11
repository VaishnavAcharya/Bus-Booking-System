using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBookingSystem.Domain.Models
{
    public class BusDetails
    {
        public int Id { get; set; }
        public int BusCompanyNameId { get; set; }
        public int BusTypeId { get; set; }
        public string OriginLocation { get; set; }
        public string  DestinationLocation { get; set; }
        public int NumOfChairSeats { get; set; }
        public int NumOfSleeperSeats { get; set; }
        public int BusNumber { get; set; }

        public BusCompanyName BusCompanyName { get; set; }
        public BusType BusType { get; set; }
    }
}

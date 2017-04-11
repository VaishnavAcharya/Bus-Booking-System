using BusBookingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusBookingSystem.WebApp.ViewModels
{
    public class BusDetailsViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int BusTypeId { get; set; }
        public string OrginLocation { get; set; }
        public string DestinationLocation{ get; set; }
        
        public IEnumerable<BusCompanyName> BusCompanyNames { get; set; }
        public IEnumerable<Location> OriginLocations { get; set; }
        public IEnumerable<Location> DestinationLocations { get; set; }
        public IEnumerable<BusType> BusTypes { get; set; }
        public IEnumerable<BusDetails> BusDetails { get; set; }
        public int NumOfChairSeats { get; set; }
        public int NumOfSleeperSeats { get; set; }
        public int BusNumber { get; set; }
    }
}
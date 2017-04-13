using BusBookingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusBookingSystem.WebApp.ViewModels
{
    public class BusDetailsViewModel
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public DateTime  DateOfJourney { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Bus Type is required")]
        public int BusTypeId { get; set; }

        [Required(ErrorMessage = "Origin Location  is required")]
        public string OriginLocation { get; set; }

        [Required(ErrorMessage = "Destination Location  is required")]
        public string DestinationLocation { get; set; }

        public IEnumerable<BusCompanyName> BusCompanyNames { get; set; }
        public IEnumerable<Location> OriginLocations { get; set; }
        public IEnumerable<Location> DestinationLocations { get; set; }
        public IEnumerable<BusType> BusTypes { get; set; }
        public IEnumerable<BusDetails> BusDetails { get; set; }

        [Required(ErrorMessage = "NumOfChairSeats  is required")]
        [Range(1, 8, ErrorMessage = "Chair Seats cannot be above 8")]
        public int NumOfChairSeats { get; set; }

        [Required(ErrorMessage = "NumOfSleeperSeats  is required")]
        [Range(1, 8, ErrorMessage = "Sleeper Seats cannot be above 8")]
        public int NumOfSleeperSeats { get; set; }

        [Required(ErrorMessage = "Bus Number  is required")]
        public string BusNumber { get; set; }
    }
}
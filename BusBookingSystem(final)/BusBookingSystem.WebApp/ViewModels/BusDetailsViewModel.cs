using BusBookingSystem.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusBookingSystem.WebApp.ViewModels
{
    public class BusDetailsViewModel
    {
        public int Id { get; set; }
        
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
        public IEnumerable<AvailabilityDetails> AvailabilityDetails { get; set; }

        [Required(ErrorMessage = "NumOfChairSeats  is required")]
        [Range(5, 8, ErrorMessage = "Chair seats must be between 5 and 8")]
        public int NumOfChairSeats { get; set; }

        [Required(ErrorMessage = "NumOfSleeperSeats  is required")]
        [Range(5, 8, ErrorMessage = "Sleeper seats must be between 5 and 8")]
        public int NumOfSleeperSeats { get; set; }

        
        [RegularExpression(@"^[A-Z]{2}\s[0-9]{1,2}\s[A-Z]{2,}\s[0-9]{4}$", ErrorMessage = "Bus number should match the registration number format(eg. GA 11 AB 1234 , DL 1 CAA 1111)")]
        [Required(ErrorMessage = "Bus Number  is required")]
        public string BusNumber { get; set; }
    }
}
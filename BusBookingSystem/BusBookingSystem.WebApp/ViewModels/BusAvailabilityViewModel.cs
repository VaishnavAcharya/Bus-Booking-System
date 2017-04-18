using BusBookingSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;


namespace BusBookingSystem.WebApp.ViewModels
{
    public class BusAvailabilityViewModel
    {
        public int Id { get; set; }
        
        [Web.Models.Validation.DateMustBeEqualOrGreaterThanCurrentDateValidation]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfJourney { get; set; }

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
       
        public int NumOfChairSeats { get; set; }

       
        public int NumOfSleeperSeats { get; set; }

        
        public string BusNumber { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public string Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookingSystem.Domain.Models
{
    public class BusDetails
    {
        public int Id { get; set; }
        public int BusCompanyNameId { get; set; }
        public int BusTypeId { get; set; }
        
        public int NumOfChairSeats { get; set; }
        public int NumOfSleeperSeats { get; set; }
        [StringLength(70)]
        [Index(IsUnique = true)]
        public string BusNumber { get; set; }

        public BusCompanyName BusCompanyName { get; set; }
        public BusType BusType { get; set; }
    }
}

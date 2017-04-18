using BusBookingSystem.Domain.EF;
using BusBookingSystem.Domain.Models;
using BusBookingSystem.WebApp.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BusBookingSystem.WebApp.Controllers
{
    public class BusAvailabilityController : Controller
    {
        BusDetailsEntity db = new BusDetailsEntity();

        public ActionResult Availability(string role)
        {
            Session["Role"] = role;
            BusDetailsViewModel mod = new BusDetailsViewModel();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            //mod.Role = role;
            mod.DateOfJourney = DateTime.Now.Date;
            return View(mod);
        }

        public ActionResult GetBuses(BusDetailsViewModel mod)
        {

            if (mod.BusTypeId == 0)
            {
                mod.BusDetails =
                     from buses in db.BusDetails.ToList()
                     where buses.OriginLocation == mod.OriginLocation && buses.DestinationLocation == mod.DestinationLocation
                     select buses;
            }

            else
            {
                mod.BusDetails =
                     from buses in db.BusDetails.ToList()
                     where buses.OriginLocation == mod.OriginLocation && buses.DestinationLocation == mod.DestinationLocation && buses.BusTypeId == mod.BusTypeId
                     select buses;
            }
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            return View("Availability", mod);
        }


        public ActionResult AddAvailability(int Id)
        {
            AvailabilityDetails AvailDetails = db.AvailabilityDetails.Find(Id);

            return View(AvailDetails);
        }


        public ActionResult SaveAvailabilityDetails(BusAvailabilityViewModel modObject)
        {
            AvailabilityDetails UpdateDetails = db.AvailabilityDetails.Find(modObject.Id);
            UpdateDetails.Monday = modObject.Monday;
            UpdateDetails.Tuesday = modObject.Tuesday;
            UpdateDetails.Wednesday = modObject.Wednesday;
            UpdateDetails.Thursday = modObject.Thursday;
            UpdateDetails.Friday = modObject.Friday;
            UpdateDetails.Saturday = modObject.Saturday;
            UpdateDetails.Sunday = modObject.Sunday;
            db.SaveChanges();
            return RedirectToAction("Availability");
        }

        public ActionResult CheckAvailability(int Id, DateTime dateOfJourney)
        {
            AvailabilityDetails AvailabilityStatus = db.AvailabilityDetails.Find(Id);
            if (dateOfJourney.Day == 1 && AvailabilityStatus.Monday)
            { ViewBag.Status = "Available"; }
            else if (dateOfJourney.Day == 2 && AvailabilityStatus.Tuesday)
            { ViewBag.Status = "Available"; }
            else if (dateOfJourney.Day == 3 && AvailabilityStatus.Wednesday)
            { ViewBag.Status = "Available"; }
            else if (dateOfJourney.Day == 4 && AvailabilityStatus.Thursday)
            { ViewBag.Status = "Available"; }
            else if (dateOfJourney.Day == 5 && AvailabilityStatus.Friday)
            { ViewBag.Status = "Available"; }
            else if (dateOfJourney.Day == 6 && AvailabilityStatus.Saturday)
            { ViewBag.Status = "Available"; }
            else if (dateOfJourney.Day == 7 && AvailabilityStatus.Sunday)
            { ViewBag.Status = "Available"; }
            else
                ViewBag.Status = "Not Available";
            return View(AvailabilityStatus);
        }
    }
}
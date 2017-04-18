using System.Linq;
using System.Web.Mvc;
using BusBookingSystem.Domain.EF;
using BusBookingSystem.WebApp.ViewModels;
using BusBookingSystem.Domain.Models;
using System;

namespace BusBookingSystem.WebApp.Controllers
{
    public class BusController : Controller
    {
        BusDetailsEntity db = new BusDetailsEntity();

        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Index()
        {
            //db.BusTypes.Add(new Domain.Models.BusType { Type = "A/C" });
            //db.SaveChanges();
            BusDetailsViewModel mod = new BusDetailsViewModel();
            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.AvailabilityDetails = db.AvailabilityDetails.Include("BusDetails").ToList();

            return View(mod);

        }

        public ActionResult addBusDetails(BusDetailsViewModel mod)
        {
            if (mod.DestinationLocation == mod.OriginLocation)
                ModelState.AddModelError("DestinationLocation", "Destination location cannot be same as the origin location");
            try
            {
                if (ModelState.IsValid)
                {
                    if (mod.Id == 0)
                    {

                        BusDetails addBusDetails = new BusDetails();
                        addBusDetails.BusCompanyNameId = mod.CompanyId;
                        addBusDetails.BusTypeId = mod.BusTypeId;
                        addBusDetails.NumOfChairSeats = mod.NumOfChairSeats;
                        addBusDetails.NumOfSleeperSeats = mod.NumOfSleeperSeats;
                        addBusDetails.BusNumber = mod.BusNumber;
                        db.BusDetails.Add(addBusDetails);
                        db.SaveChanges();

                        AvailabilityDetails availDetails = new AvailabilityDetails();
                        availDetails.BusDetailsId = addBusDetails.Id;
                        availDetails.OriginLocation = mod.OriginLocation;
                        availDetails.DestinationLocation = mod.DestinationLocation;
                        db.AvailabilityDetails.Add(availDetails);

                        AvailabilityDetails addReturnJourneyDetails = new AvailabilityDetails();
                        addReturnJourneyDetails.BusDetailsId = addBusDetails.Id;
                        addReturnJourneyDetails.OriginLocation = mod.DestinationLocation;
                        addReturnJourneyDetails.DestinationLocation = mod.OriginLocation;
                        addReturnJourneyDetails.IsReturn = true;
                        db.AvailabilityDetails.Add(addReturnJourneyDetails);
                        db.SaveChanges();




                    }

                    else
                    {
                        BusDetails editedDetails = db.BusDetails.Find(mod.Id);
                        editedDetails.BusCompanyNameId = mod.CompanyId;
                        editedDetails.BusTypeId = mod.BusTypeId;
                        editedDetails.NumOfChairSeats = mod.NumOfChairSeats;
                        editedDetails.NumOfSleeperSeats = mod.NumOfSleeperSeats;
                        editedDetails.BusNumber = mod.BusNumber;


                        AvailabilityDetails editedAvailDetails = db.AvailabilityDetails.Where(m => m.BusDetailsId == editedDetails.Id).FirstOrDefault();
                        // editedAvailDetails.BusDetailsId = editedDetails.Id;
                        editedAvailDetails.OriginLocation = mod.OriginLocation;
                        editedAvailDetails.DestinationLocation = mod.DestinationLocation;

                        AvailabilityDetails editReturnJourneyDetails = db.AvailabilityDetails.Where(m => m.BusDetailsId == editedDetails.Id && m.IsReturn == true).FirstOrDefault();
                        editReturnJourneyDetails.OriginLocation = mod.DestinationLocation;
                        editReturnJourneyDetails.DestinationLocation = mod.OriginLocation;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("Cannot insert duplicate key row"))
                {
                    ModelState.AddModelError("BusNumber", "This bus number is already in use");
                }
            }

            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.AvailabilityDetails = db.AvailabilityDetails.Include("BusDetails").ToList();
            return View("Index", mod);

        }

        public ActionResult EditBusDetails(BusDetailsViewModel mod)
        {
            BusDetails editDetails = db.BusDetails.Find(mod.Id);
            mod.CompanyId = editDetails.BusCompanyNameId;
            mod.BusTypeId = editDetails.BusTypeId;
            mod.NumOfChairSeats = editDetails.NumOfChairSeats;
            mod.NumOfSleeperSeats = editDetails.NumOfSleeperSeats;
            mod.BusNumber = editDetails.BusNumber;
            mod.Id = editDetails.Id;

            AvailabilityDetails editAvailDetails = db.AvailabilityDetails.FirstOrDefault(m => m.BusDetailsId == mod.Id);
            mod.OriginLocation = editAvailDetails.OriginLocation;
            mod.DestinationLocation = editAvailDetails.DestinationLocation;

            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.AvailabilityDetails = db.AvailabilityDetails.Include("BusDetails").ToList();
           
            return View("Index", mod);
        }

        public ActionResult DeleteBusDetails(BusDetailsViewModel mod)
        {
            BusDetails deleteDetails = db.BusDetails.Find(mod.Id);
            db.BusDetails.Remove(deleteDetails);

            //AvailabilityDetails deleteavailDetails = db.AvailabilityDetails.;
            //db.AvailabilityDetails.Remove(deleteavailDetails);
            //db.SaveChanges();

            foreach (var availDetails in db.AvailabilityDetails.Where(m => m.BusDetailsId == mod.Id).ToList())
            {
                
                db.AvailabilityDetails.Remove(availDetails);
            }
            db.SaveChanges();
            mod.Id = 0;
            return RedirectToAction("Index");
        }






    }
}
﻿using System.Linq;
using System.Web.Mvc;
using BusBookingSystem.Domain.EF;
using BusBookingSystem.WebApp.ViewModels;
using BusBookingSystem.Domain.Models;

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
            mod.BusDetails = db.BusDetails.ToList();

            return View(mod);

        }

        public ActionResult AddBusDetails(BusDetailsViewModel mod)
        {
            if(ModelState.IsValid)
            {
                if (mod.Id == 0)
                {
                    BusDetails AddBusDetails = new BusDetails();
                    AddBusDetails.BusCompanyNameId = mod.CompanyId;
                    AddBusDetails.BusTypeId = mod.BusTypeId;
                    AddBusDetails.OriginLocation = mod.OriginLocation;
                    AddBusDetails.DestinationLocation = mod.DestinationLocation;
                    AddBusDetails.NumOfChairSeats = mod.NumOfChairSeats;
                    AddBusDetails.NumOfSleeperSeats = mod.NumOfSleeperSeats;
                    AddBusDetails.BusNumber = mod.BusNumber;
                    db.BusDetails.Add(AddBusDetails);

                    AvailabilityDetails AvailDetails = new AvailabilityDetails();
                    AvailDetails.BusNumber = mod.BusNumber;
                    AvailDetails.OriginLocation = mod.OriginLocation;
                    AvailDetails.DestinationLocation = mod.DestinationLocation;
                    db.AvailabilityDetails.Add(AvailDetails);
                    db.SaveChanges();
                }

                else
                {
                    BusDetails EditedDetails = db.BusDetails.Find(mod.Id);
                    EditedDetails.BusCompanyNameId = mod.CompanyId;
                    EditedDetails.BusTypeId = mod.BusTypeId;
                    EditedDetails.OriginLocation = mod.OriginLocation;
                    EditedDetails.DestinationLocation = mod.DestinationLocation;
                    EditedDetails.NumOfChairSeats = mod.NumOfChairSeats;
                    EditedDetails.NumOfSleeperSeats = mod.NumOfSleeperSeats;
                    EditedDetails.BusNumber = mod.BusNumber;


                    AvailabilityDetails AvailDetails = db.AvailabilityDetails.Find(mod.Id);
                    AvailDetails.BusNumber = mod.BusNumber;
                    AvailDetails.OriginLocation = mod.OriginLocation;
                    AvailDetails.DestinationLocation = mod.DestinationLocation;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.BusDetails = db.BusDetails.ToList();
            return View("Index",mod);
            
        }

        public ActionResult EditBusDetails(BusDetailsViewModel mod)
        {
            BusDetails EditDetails = db.BusDetails.Find(mod.Id);
            mod.CompanyId = EditDetails.BusCompanyNameId;
            mod.BusTypeId = EditDetails.BusTypeId;
            mod.OriginLocation = EditDetails.OriginLocation;
            mod.DestinationLocation = EditDetails.DestinationLocation;
            mod.NumOfChairSeats = EditDetails.NumOfChairSeats;
            mod.NumOfSleeperSeats = EditDetails.NumOfSleeperSeats;
            mod.BusNumber = EditDetails.BusNumber;
            mod.Id = EditDetails.Id;
            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.BusDetails = db.BusDetails.ToList();
            return View("Index", mod);
        }

        public ActionResult DeleteBusDetails(BusDetailsViewModel mod)
        {
            BusDetails DeleteDetails = db.BusDetails.Find(mod.Id);
            db.BusDetails.Remove(DeleteDetails);

            AvailabilityDetails DeleteAvailDetails = db.AvailabilityDetails.Find(mod.Id);
            db.AvailabilityDetails.Remove(DeleteAvailDetails);
            db.SaveChanges();
            mod.Id = 0;
            return RedirectToAction("Index");
        }

       

     

        
    }
}
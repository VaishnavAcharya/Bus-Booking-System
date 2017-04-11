using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Domain.EF;
using BusBookingSystem.WebApp.ViewModels;
using BusBookingSystem.Domain.Models;

namespace BusBookingSystem.WebApp.Controllers
{
    public class BusController : Controller
    {
        BusDetailsEntity db = new BusDetailsEntity();

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
            if (mod.Id == 0)
            {
                BusDetails AddBusDetails = new BusDetails();
                AddBusDetails.BusCompanyNameId = mod.CompanyId;
                AddBusDetails.BusTypeId = mod.BusTypeId;
                AddBusDetails.OriginLocation = mod.OrginLocation;
                AddBusDetails.DestinationLocation = mod.DestinationLocation;
                AddBusDetails.NumOfChairSeats = mod.NumOfChairSeats;
                AddBusDetails.NumOfSleeperSeats = mod.NumOfSleeperSeats;
                AddBusDetails.BusNumber = mod.BusNumber;
                db.BusDetails.Add(AddBusDetails);
                db.SaveChanges();
            }

            else
            {
                BusDetails EditedDetails = new BusDetails();
                EditedDetails.BusCompanyNameId = mod.CompanyId;
                EditedDetails.BusTypeId = mod.BusTypeId;
                EditedDetails.OriginLocation = mod.OrginLocation;
                EditedDetails.DestinationLocation = mod.DestinationLocation;
                EditedDetails.NumOfChairSeats = mod.NumOfChairSeats;
                EditedDetails.NumOfSleeperSeats = mod.NumOfSleeperSeats;
                EditedDetails.BusNumber = mod.BusNumber;
                db.BusDetails.Add(EditedDetails);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult EditBusDetails(BusDetailsViewModel mod)
        {
            BusDetails EditDetails = db.BusDetails.Find(mod.Id);
            mod.CompanyId = EditDetails.BusCompanyNameId;
            mod.BusTypeId = EditDetails.BusTypeId;
            mod.OrginLocation = EditDetails.OriginLocation;
            mod.DestinationLocation = EditDetails.DestinationLocation;
            mod.NumOfChairSeats = EditDetails.NumOfChairSeats;
            mod.NumOfSleeperSeats = EditDetails.NumOfSleeperSeats;
            mod.BusNumber = EditDetails.BusNumber;

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
            db.SaveChanges();
            mod.Id = 0;
            return RedirectToAction("Index");
        }

        public ActionResult Availability()
        {
            return View();
        }
    }
}
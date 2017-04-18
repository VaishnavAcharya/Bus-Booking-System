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
            BusAvailabilityViewModel mod = new BusAvailabilityViewModel();
            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.DateOfJourney = DateTime.Now.Date;
            return View(mod);
        }

        public ActionResult GetBuses(BusAvailabilityViewModel mod)
        {
            if (mod.DestinationLocation == mod.OriginLocation)
                ModelState.AddModelError("DestinationLocation", "Destination location cannot be same as the origin location");
            if ((string)Session["Role"] == "User")
            {
                if (ModelState.IsValid)
                {
                    if (mod.BusTypeId == 0)
                    {
                        if (mod.DateOfJourney.DayOfWeek.ToString() == "Monday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Monday == true
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Tuesday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Tuesday == true
                                                 select details;
                        }


                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Wednesday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Wednesday == true
                                                 select details;
                        }


                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Thursday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Thursday == true
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Friday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Friday == true
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Saturday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Saturday == true
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Sunday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Sunday == true
                                                 select details;
                        }


                    }

                    else
                    {

                        if (mod.DateOfJourney.DayOfWeek.ToString() == "Monday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Monday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Tuesday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Tuesday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }


                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Wednesday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Wednesday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }


                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Thursday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Thursday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Friday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Friday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Saturday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Saturday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }

                        else if (mod.DateOfJourney.DayOfWeek.ToString() == "Sunday")
                        {
                            mod.AvailabilityDetails =
                                                 from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                                                 where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.Sunday == true && details.BusDetails.BusTypeId == mod.BusTypeId
                                                 select details;
                        }
                    }
                }



            }

            else
            {
                if (mod.BusTypeId == 0)
                {
                    mod.AvailabilityDetails =
                         from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                         where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation
                         select details;
                }

                else
                {
                    mod.AvailabilityDetails =
                         from details in db.AvailabilityDetails.Include("BusDetails").ToList()
                         where details.OriginLocation == mod.OriginLocation && details.DestinationLocation == mod.DestinationLocation && details.BusDetails.BusTypeId == mod.BusTypeId
                         select details;
                }

            }



            mod.OriginLocations = db.Locations.ToList();
            mod.DestinationLocations = db.Locations.ToList();
            mod.BusTypes = db.BusTypes.ToList();
            mod.BusCompanyNames = db.BusCompanyNames.ToList();
            return View("Availability", mod);
        }


        public ActionResult AddAvailability(int Id, string BusNumber)
        {
            AvailabilityDetails AvailDetails = db.AvailabilityDetails.Find(Id);
            //AvailDetails.BusDetails.BusNumber = BusNumber;
            return View(AvailDetails);
        }


        public ActionResult SaveAvailabilityDetails(AvailabilityDetails modObject)
        {
            AvailabilityDetails updateDetails = db.AvailabilityDetails.Find(modObject.Id);
            
            if (updateDetails.IsReturn)
            {
                var otherJourneyDetails = db.AvailabilityDetails.Where(m => m.BusDetailsId == updateDetails.BusDetailsId && !m.IsReturn).FirstOrDefault();
                return IsDayOfWeekCoincide(otherJourneyDetails, updateDetails, modObject);
            }

            else
            {
                var otherJourneyDetails = db.AvailabilityDetails.Where(m => m.BusDetailsId == updateDetails.BusDetailsId && m.IsReturn).FirstOrDefault();
                return IsDayOfWeekCoincide(otherJourneyDetails, updateDetails, modObject);

            }


            //updateDetails.Monday = modObject.Monday;
            //updateDetails.Tuesday = modObject.Tuesday;
            //updateDetails.Wednesday = modObject.Wednesday;
            //updateDetails.Thursday = modObject.Thursday;
            //updateDetails.Friday = modObject.Friday;
            //updateDetails.Saturday = modObject.Saturday;
            //updateDetails.Sunday = modObject.Sunday;
            //db.SaveChanges();
            //return RedirectToAction("Availability");
        }

        public ActionResult IsDayOfWeekCoincide(AvailabilityDetails otherJourneyDetails, AvailabilityDetails updateDetails, AvailabilityDetails modObject)
        {
            if (otherJourneyDetails.Monday && modObject.Monday)
            {
                ModelState.AddModelError("Monday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on monday");
            }
            
            

            if (otherJourneyDetails.Tuesday && modObject.Tuesday)
            {
                ModelState.AddModelError("Tuesday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on Tuesday");
            }
            

            if (otherJourneyDetails.Wednesday && modObject.Wednesday)
            {
                ModelState.AddModelError("Wednesday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on Wednesday");
            }

            if (otherJourneyDetails.Thursday && modObject.Thursday)
            {
                ModelState.AddModelError("Thursday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on Thursday");
            }

           
            if (otherJourneyDetails.Friday && modObject.Friday)
            {
                ModelState.AddModelError("Friday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on Friday");
            }

          

            if (otherJourneyDetails.Saturday && modObject.Saturday)
            {
                ModelState.AddModelError("Saturday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on Saturday");
            }

            

            if (otherJourneyDetails.Sunday && modObject.Sunday)
            {
                ModelState.AddModelError("Sunday", "Bus is travelling from " + otherJourneyDetails.OriginLocation + " to " + otherJourneyDetails.DestinationLocation + " on Sunday");
            }
            

            if(ModelState.IsValid)
            {
                updateDetails.Monday = modObject.Monday;
                updateDetails.Tuesday = modObject.Tuesday;
                updateDetails.Wednesday = modObject.Wednesday;
                updateDetails.Thursday = modObject.Thursday;
                updateDetails.Friday = modObject.Friday;
                updateDetails.Saturday = modObject.Saturday;
                updateDetails.Sunday = modObject.Sunday;
                db.SaveChanges();
                return RedirectToAction("Availability");
            }
            

            return View("AddAvailability",updateDetails);
        }
    }
}
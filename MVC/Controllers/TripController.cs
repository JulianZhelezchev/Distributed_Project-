using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
      /*  public ActionResult Index() 

        {
            List<TripsVM> TripsVM = new List<TripsVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetTrips()) 
                {
                    TripsVM.Add(new TripsVM(item));
                }

            }

            return View(TripsVM);
        }  */
        public ActionResult Index(string search)

        {
            List<TripsVM> VMs = new List<TripsVM>();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    foreach (var item in service.GetTripsBySearch(search))
                    {
                        VMs.Add(new TripsVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetTrips())
                    {
                        VMs.Add(new TripsVM(item));
                    }
                }
            }
            return View(VMs);
        }

        [HttpPost]
        public ActionResult Create(TripsVM tripsVM)
        {
            try

            {   // izwikwame Service
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        TripDTO tripDTO = new TripDTO  
                        {
                            MeetPlace = tripsVM.MeetPlace,
                            FinalDestination = tripsVM.FinalDestination,
                            Date = tripsVM.Date,
                            DistanceKms = tripsVM.DistanceKms,
                            TripPrice = tripsVM.TripPrice,
                            Details = tripsVM.Details
                           

                    
                    };
                        service.PostTrip(tripDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(TripsVM VM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        TripDTO dto = new TripDTO
                        {
                            Id = VM.Id,
                            MeetPlace = VM.MeetPlace,
                            FinalDestination = VM.FinalDestination,
                            Date = VM.Date,
                            DistanceKms = VM.DistanceKms,
                            TripPrice = VM.TripPrice,
                            Details = VM.Details
                        };

                        service.PutTrip(dto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }



        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TripsVM vm = new TripsVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var DTO = service.GetTripById(id);
                vm = new TripsVM(DTO);
            }
            return View(vm);
        }
        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteTrip(id); 
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            TripsVM tripVM = new TripsVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                tripVM = new TripsVM(service.GetTripById(id));
            }
            return View(tripVM); 
        }
        
    }
}
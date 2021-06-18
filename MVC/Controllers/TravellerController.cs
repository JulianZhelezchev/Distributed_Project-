using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class TravellerController : Controller
    {
        // GET: Traveller
       
        
       /* public ActionResult Index()

        {
           List<TravellersVM> TravellersVM = new List<TravellersVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetTravellers())
                {
                    TravellersVM.Add(new TravellersVM(item));
                }

            }

            return View(TravellersVM); 
        }
        */
        public ActionResult Index(string search)

        {
            List<TravellersVM> VMs = new List<TravellersVM>();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    foreach (var item in service.GetTravellerBySearch(search))
                    {
                        VMs.Add(new TravellersVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetTravellers())
                    {
                        VMs.Add(new TravellersVM(item));
                    }
                }
            }
            return View(VMs);
        }

        [HttpPost]
        public ActionResult Create(TravellersVM travellersVM)
        {
            try

            {   // izwikwame Service
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        TravellerDTO travellerDTO =  new TravellerDTO
                        {
                            FirstName = travellersVM.FirstName,
                            LastName = travellersVM.LastName,
                            Age = travellersVM.Age,
                            DesiredPrice = travellersVM.DesiredPrice,
                            PhoneNumber = travellersVM.PhoneNumber,
                            StartDestination = travellersVM.StartDestination,
                            EndDestination = travellersVM.EndDestination

                    };
                        service.PostTraveller(travellerDTO);

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

        [HttpPost]
        public ActionResult Edit(TravellersVM VM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        TravellerDTO dto = new TravellerDTO
                        {
                            Id = VM.Id,
                           
                            FirstName = VM.FirstName,
                            LastName = VM.LastName,
                            Age = VM.Age,
                            DesiredPrice = VM.DesiredPrice,
                            PhoneNumber = VM.PhoneNumber,
                            StartDestination = VM.StartDestination,
                            EndDestination = VM.EndDestination
                        };

                        service.PutTraveller(dto);
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
            TravellersVM vm = new TravellersVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var DTO = service.GetTravellerById(id);
                vm = new TravellersVM(DTO);
            }
            return View(vm);
        }
        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteTraveller(id); 
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            TravellersVM travellerVM = new TravellersVM(); 
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                travellerVM = new TravellersVM(service.GetTravellerById(id)); 
            }
            return View(travellerVM); 
        }
    }
}
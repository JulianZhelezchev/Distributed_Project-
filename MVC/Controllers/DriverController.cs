using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
    
        public ActionResult Index(string search)

        {
            List<DriversVM> VMs = new List<DriversVM>();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    foreach (var item in service.GetDriversBySearch(search))
                    {
                        VMs.Add(new DriversVM(item));
                    }
                }
                else
                {
                    foreach (var item in service.GetDrivers())
                    {
                        VMs.Add(new DriversVM(item));
                    }
                }
            }
            return View(VMs);
        }
           
   
        [HttpPost]
        public ActionResult Create(DriversVM driversVM)
        {
            try

            {   // izwikwame Service
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        DriverDTO driverDTO = new DriverDTO 
                        {
                            FirstName = driversVM.FirstName,
                            LastName = driversVM.LastName,
                            Age = driversVM.Age,
                            TripPrice = driversVM.TripPrice,
                            PhoneNumber = driversVM.PhoneNumber,
                            VehicleType = driversVM.VehicleType,
                            VehicleBrand = driversVM.VehicleBrand


                    };
                        service.PostDriver(driverDTO);

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

       
        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteDriver(id);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(DriversVM VM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        DriverDTO dto = new DriverDTO
                        {
                            Id = VM.Id,
                            FirstName = VM.FirstName,
                            LastName = VM.LastName,
                            Age = VM.Age,
                            TripPrice = VM.TripPrice,
                            PhoneNumber = VM.PhoneNumber,
                            VehicleType = VM.VehicleType,
                            VehicleBrand = VM.VehicleBrand
                        };

                        service.PutDriver(dto);
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
         DriversVM vm = new DriversVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var DTO = service.GetDriverById(id);
                vm = new DriversVM(DTO);
            }
            return View(vm);
        }

        public ActionResult Details(int id)
        {
            DriversVM driverVM = new DriversVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                driverVM = new DriversVM(service.GetDriverById(id));
            }
            return View(driverVM);
        }
        
    }
    }

using System;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocService.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _pataients;

        //Nurse
        public PatientController( IPatientRepository pataients)
        {
           
            _pataients = pataients;
        } 

        public class PatientViewModel 
        {
            public Patient Patient { get; set; }
            public IEnumerable<Patient> Patients { get; set; }
        }

       public async Task<IActionResult> Index()
        {
            // return View(await _context.Doctors.ToListAsync());
            PatientViewModel pvm = new PatientViewModel();
            pvm.Patient = new Patient();
            pvm.Patients =  _pataients.GetAllPatients();
            return View(pvm);
        }



public IActionResult NewPatient()
        {


            _pataients.SaveDatabase();
            return View("NewPatient");
        }
      

    [HttpPost]
    [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewPatient([Bind
        ("Id,FirsName,LastName,PatientCode,Gender,BloodType,DateOfBirth,Phone,EmailAddress, Address, Agreement")]
         Patient patiet)
        {

            await _pataients.AddPatient(patiet);
            _pataients.SaveDatabase();
            //redirectUrl

            return RedirectToRoute(new { controller = "Nurse", action = "Index" });

            return View(patiet);
        }
  

    }
}

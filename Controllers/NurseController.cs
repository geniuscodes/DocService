using System;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocService.Controllers
{
    public class NurseController : Controller
    {
        
        //Nurse Repository
        private readonly INurseRepository _nurses;
        private readonly IDoctorRepository _doctors;
        private readonly IPatientRepository _pataients;

        //Nurse
        public NurseController(INurseRepository nurses,
        IDoctorRepository doctors,IPatientRepository pataients)
        {
            _nurses = nurses;
            _doctors = doctors;
            _pataients = pataients;
        }
/// <summary>
/// The controller will be responsible for   nurse  to manage the 
/// Prescriptions Patients Checkups and So On 
/// </summary>
/// <returns></returns>
        public class PatientViewModel 
        {
            public Patient Patient { get; set; }
            public IEnumerable<Patient?> Patients { get; set; }
        }

       public async Task<IActionResult> Index()
        {
            // return View(await _context.Doctors.ToListAsync());
            PatientViewModel pvm = new PatientViewModel();
            pvm.Patient = new Patient();
            pvm.Patients =  _pataients.GetAllPatients();
            return View(pvm);
        }

// GET
  public IActionResult NewPatient()
        {
            return View("NewPatient");
        }
        [HttpPost]
        public async Task<IActionResult> NewPatient([Bind
        ("Id,FirsName,LastName,PatientCode,Gender,BloodType,DateOfBirth,Phone,EmailAddress, Address, Agreement")]
         Patient patiet)
        {

            await _pataients.AddPatient(patiet);
            _doctors.SaveDatabase();
            return RedirectToAction(nameof(Index));

            return View(patiet);
        }
        //Edit


//////////////////////////////////!!For Tesing Func //////////////////////////////////

        //Index
        [HttpGet]
        [Route("nurse/all")]
        public  ActionResult<IEnumerable<Nurse>> Nurses()
        {
            var nurses = _nurses.GetAllNurses();
            return Ok(nurses);
        }

        //Details
        [HttpGet]
        [Route("nurse/{id}")]
        public ActionResult<Nurse> Nurse(int id)
        {
            var nurse = _nurses.GetANurse(id);
            return Ok(nurse);
        }

        //Removecc
        [HttpDelete]
        [Route("nurse/delete/{id}")]
        public async Task<ActionResult<Nurse>> DeleteNurse(int id, Nurse  n)
        {
            var nurse = _nurses.GetANurse(id);
            switch (nurse)
            {
                case null:
                    return NotFound();
                default:
                 await Task.Run(() =>
                   _nurses.DeleteNurse(nurse.Result)
                 .ContinueWith(
                     t =>  _nurses.SaveDatabase()));
                    return Ok(nurse.Result);
            }
          
        }

        //SearchByName
        [HttpGet]
        [Route("nurse/search/{name}")]
        
        public async Task<ActionResult<IEnumerable<Nurse>>> SearchByName(string name)
        {
            var nurses = _nurses.SearchByName(name);
            return Ok(nurses);

        }

       
    }
}

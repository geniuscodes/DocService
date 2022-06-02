using System;
using System.Diagnostics;
using AutoMapper;
using DocService.Models.Data;
using DocService.Models.DTO;
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
        private readonly IAppointmentRepository _appointments;
        private readonly IMapper _mapper;
        private readonly AppDbContext _database;

        //Nurse
        public NurseController(INurseRepository nurses,
        IDoctorRepository doctors, IPatientRepository pataients,
        IAppointmentRepository appointments, IMapper mapper,
        AppDbContext database
        )
        {
            _nurses = nurses;
            _doctors = doctors;
            _pataients = pataients;
            _appointments = appointments;
            _mapper = mapper;
            _database = database;
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


        //Nurses -   MVC 
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Doctors.ToListAsync());
            PatientViewModel pvm = new PatientViewModel();
            pvm.Patient = new Patient();
            pvm.Patients = _pataients.GetAllPatients();
            return View(pvm);
        }

        // GET
        public IActionResult NewPatient()
        {
            return View("NewPatient");
        }
       


        //CLINIC - Appointments  MVC 


        public ActionResult<IEnumerable<Appointment>> Appointments()

        {
           
                var allAppointments = _appointments.GetAppointments();
                return View();
            
        }





















        //////////////////////////////////!!For Tesing Func //// !!API //////////////////////////////

        //Index
        [HttpGet]
        [Route("nurse/all")]
        public ActionResult<IEnumerable<Nurse>> Nurses()
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
        public async Task<ActionResult<Nurse>> DeleteNurse(int id, Nurse n)
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
                        t => _nurses.SaveDatabase()));
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


        //Manage Apppointments

        [HttpGet]
        [Route("nurse/appointments/all")]
        public async Task<ActionResult<IEnumerable<AppointmentReadDTO>>> GetAllApointments()
        {

            var allApp =  _appointments.GetAppointments();
            return Ok(allApp);


        }

        [HttpGet]
        [Route("nurse/appointments/{id}")]
        public async Task<ActionResult<AppointmentReadDTO>> GetAppointmentById(int id)
        {
            var app = await _appointments.GetAppointment(id);
            return Ok((app));
        }

        [HttpPost]
        [Route("nurse/appointments")]
        public async Task<ActionResult<AppointmentCreateDTO>> NewAppointment([FromBody] AppointmentCreateDTO appointment)
        {

            var app = _appointments.AddAppointment(appointment);
            //Break Point  databaseSave
            return Ok(app);

        }

        [HttpPut("{AppointmentId}")]
        [ProducesResponseType(200)]
       
        public  async Task<ActionResult<AppointmentEditDTO>> UpdateAppointment(int AppointmentId, [FromBody] AppointmentEditDTO appointment)
        {

            //map 
            if(!ModelState.IsValid)
            {
                return BadRequest("Not That nOW ????");
            }
          
            var fromDTOtoModel = _mapper.Map<AppointmentEditDTO, Appointment>(appointment);
            var IdChecker =  _database.Appointments.FirstOrDefault(x => x.Id == AppointmentId);
            if (IdChecker != null)
            {

                IdChecker.PatientId = appointment.PatientId;
                IdChecker.doctorId = appointment.DoctorId;
                IdChecker.PatientType = appointment.PatientType;
                IdChecker.NextVisitDate = appointment.AppointmentDate;
                IdChecker.AppointmentTime = appointment.AppointmentTime;
                IdChecker.Advice = appointment.Advice;
                IdChecker.Comment = appointment.Comment;
                _database.SaveChanges();

                //map edited model back to DTO 
                var updatedModel = _mapper.Map<Appointment, AppointmentEditDTO>(IdChecker);
                return Ok(updatedModel);
            }
            else
            {
                return NotFound("tHAT oNE is Not FounD ----");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {

            var FindAppId =  await _database.Appointments.FindAsync(id);
            if (FindAppId == null)
            {

                return NotFound($"No Appointment Found--");
               
            }

             _database.Appointments.Remove(FindAppId);
            _database.SaveChanges();
            return Ok("Appointment Deleted");
        }
    }
}

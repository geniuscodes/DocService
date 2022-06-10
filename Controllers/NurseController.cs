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

        //Getting Patients Per Doctor This will return a Grouped List
        [HttpGet]
        [Route("Home/Patientspd")]
        public ActionResult Ppd()
        {
            List<Appointment>? appointments = _database.Appointments.ToList();
            var docs = _database.Doctors.ToList();
            var PatientsPerDoctor = from r in appointments
                     join d in docs
                     on r.doctorId equals d.Id
                     orderby d.FirstName
                     group r by d.FirstName into grp
                     select new { Doctor = grp.Key, Patients = grp.Count() };

        
         

            return Ok(PatientsPerDoctor);

        }

        //Get the Number OF Patients Per Doctor on Average
        //Edit the Method for doctor to see their patients can filter by Date
        //Get Appointmets of a Doctor by Specifiying the Id on Param
        //Get Appointmets of a Doctor by Specifiying the Id on Param
        [HttpGet]
        [Route("Home/GetAveragePatientsPerDoctor")]
        
        public ActionResult GetAveragePatientsPerDoctor()
        {
            //DataSources
            var appointments = _database.Appointments.ToList();
            var doctors = _database.Doctors.ToList() ;
            //First Group the Results
            var results = from a in appointments
                          join d in doctors
                          on a.doctorId equals d.Id
                          //Filter By Date ?
                          //where DateCreated BETWEEN ( day1, day 2)
                          //Where DateCreated IN (day1, day2 )  // From User Param
                          orderby d.FirstName
                          group a by d.FirstName into grp
                          select new { Doc = grp.Key, Patients = grp.Count() };



            //avreage 
            var AverageResult = results.Average(x => x.Patients);
            //toInt
            var AvavargeIntReslults = (int)AverageResult;

            return Ok($"On Average the Doc has {AvavargeIntReslults}  Patients");

        }

        //Total Doctors
        [HttpGet]
        [Route("Home/TotalDoctors")]
        public ActionResult TotalDocs()
        {
            //data sources
            var rslt = _appointments.totalCount("Doctors");
   
            return Ok($"We Currently have {rslt} Professional Doctors in Our Hospital");

        }

        //Total Patients
        [HttpGet]
        [Route("Home/TotalPatients")]
        public ActionResult TotalPatients()
        {
            var patients = _database.Patients.ToList();
            int toatl = patients.Count();
            return Ok($"We Currently have {toatl} Patients  in Our Hospital");
        }

        //Totals
        [HttpGet]
        [Route("Home/TotalAppointments",Name = "TotalAppointments")]
        public ActionResult TotalAppointments ()
        {
            //
            var appointments = _database.Appointments.ToDictionary(x => x.Id, u=> u.Patient);
            //
            int appo = appointments.Count();
            //
            return Ok($"We Have Manged {appo} Appointments and Counting ! ");
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
        [Route("appointments/{PatName}")]
        public async Task<ActionResult<AppointmentReadDTO>> GetAppoinmentByPatientName(string PatName)
        {
            var appointment = _appointments.GetAppointmentByPatientName(PatName);
            return Ok(appointment);
        }
        [HttpGet]
        [Route("nurse/appointments/{id}")]
        public async Task<ActionResult<AppointmentReadDTO>> GetAppointmentById(int id)
        {
            var appointment = _appointments.GetAppointment(id);
            return Ok(appointment);
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

using AutoMapper;
using DocService.Models.Data;
using DocService.Models.DTO;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DocService.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointments;
        private readonly IMapper _mapper;
        private readonly AppDbContext _database;
        public AppointmentsController(IAppointmentRepository appointments,
            IMapper mapper, AppDbContext database)
        {
            _appointments = appointments;
            _mapper = mapper;
            _database = database;
         }

        public class PatientViewModel
        {
            public AppointmentReadDTO AppointmentReadDTO { get; set; }
            public IEnumerable<AppointmentReadDTO?> Appointments { get; set; }
        }


        //Nurses -   MVC 
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Doctors.ToListAsync());
            PatientViewModel pvm = new PatientViewModel();
            pvm.AppointmentReadDTO = new AppointmentReadDTO();
            pvm.Appointments = _appointments.GetAppointments();

           
            return View(pvm);
        }
        // GET: AppointmentsController
     

        // GET: AppointmentsController/Details/5

        public ActionResult Details(int Id)
        {

            var appointment = _appointments.GetAppointment(Id);
            return View(appointment);
        }

        public IActionResult AddAppointment()
        {

            ViewData["DoctorId"] = new SelectList(_database.Doctors, "Id", "FirstName");
            ViewData["PatientId"] = new SelectList(_database.Patients, "Id", "FirsName");

            return View();
        }


        // GET: AppointmentsController/Create
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAppointment([Bind] AppointmentCreateDTO appointment)
        {

            await _appointments.AddAppointment(appointment);
            await _database.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            ViewData["PatientId"] = new SelectList(_database.Patients, "Id", "FirsName", appointment.PatientId);
            ViewData["DoctorId"] = new SelectList(_database.Doctors, "Id", "FirstName", appointment.DoctorId);
            return RedirectToAction(nameof(Index));
        }

        // POST: AppointmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentsController/Edit/5
        public ActionResult UpdateAppointment(int? id)
        {

            //
            if (id == null) return NotFound();

            var app = _database.Appointments.FirstOrDefault(x => x.Id == id);
            //if found
            if(app != null)
            {
                ViewData["PatientId"] = new SelectList(_database.Patients, "Id", "FirsName", app.PatientId);
                ViewData["doctorId"] = new SelectList(_database.Doctors, "Id", "FirstName", app.doctorId);
                var re = _mapper.Map<Appointment, AppointmentReadDTO>(app);
                return View(re);
            }

            return RedirectToAction(nameof(Index));
                   
     
        }

        // POST: AppointmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

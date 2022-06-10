using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DocService.Models;
using DocService.Models.Data;
using DocService.Repositories.Interfaces;
using DocService.Models.DTO;
using DocService.Models.Entities;
using DocService.Repositories.Repos;

namespace DocService.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly IPatientRepository _patientRepository;
    private readonly IAppointmentRepository _appointmentRepository;

    public HomeController(ILogger<HomeController> logger,
        AppDbContext context,
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository)
    {
        _logger = logger;
        _context = context;
        _appointmentRepository = appointmentRepository;
        _patientRepository = patientRepository;
    }

    public class PatientViewModel
    {
        public AppointmentReadDTO aprd { get; set; }
        public AppointmentRepository appointment { get; set; }
        public  int docs { get; set; }
        public  int patients { get; set; }
        public  int appointments { get; set; }
        public  int nurses { get; set; }
        public  int avergagePatients { get; set; }
        public  int medicine { get; set; }
        public IEnumerable<Patient?> Patients { get; set; }
    }


    //Nurses -   MVC 
    public async Task<IActionResult> Index()
    {
  
        PatientViewModel pvm = new PatientViewModel();
        pvm.aprd = new AppointmentReadDTO();
        pvm.docs = _appointmentRepository.totalCount("Doctors");
        pvm.patients = _appointmentRepository.totalCount("Patients");
        pvm.appointments = _appointmentRepository.totalCount("Appointments");
        pvm.medicine = _appointmentRepository.totalCount("Medicines");
        pvm.nurses = _appointmentRepository.totalCount("Nurses");
        pvm.avergagePatients = _appointmentRepository.totalCount("AveragePatients");
        pvm.Patients = _patientRepository.GetAllPatients();
        return View(pvm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    
}

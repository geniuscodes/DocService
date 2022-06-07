using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DocService.Models;
using DocService.Models.Data;
using DocService.Repositories.Interfaces;

namespace DocService.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly IPatientRepository _patientRepository;

    public HomeController(ILogger<HomeController> logger,
        AppDbContext context,
        IPatientRepository patientRepository)
    {
        _logger = logger;
        _context = context;
        _patientRepository = patientRepository;
    }

    public IActionResult Index()
    {
        var patients = _patientRepository.GetAllPatients();
        return View(patients);
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

using DocService.Models.Data;
using DocService.Models.Entities;
using DocService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using DocService.Models.Data.Identity;

namespace DocService.Controllers
{



    //Authorize for Doctors, Managemement
    [Authorize(Roles = StaticRoles.Doctor + "," + StaticRoles.Management)]
    public class DoctorController : Controller
    {
        private readonly Models.Data.AppDbContext _context;
        private readonly IDoctorRepository _doctors;
        private readonly RoleManager<IdentityRole> _rolesManager;

        public DoctorController(Models.Data.AppDbContext context,
         IDoctorRepository doctor,
         RoleManager<IdentityRole> rolesManager)
        {
            _context = context;
            _rolesManager = rolesManager;
            _doctors = doctor;
        }

        [Authorize(Roles = StaticRoles.Doctor + "," + StaticRoles.Management)]
        public  async Task<ActionResult> Index()
        {

            if (User.Identity.IsAuthenticated && User.IsInRole(StaticRoles.Doctor) ||
            User.Identity.IsAuthenticated &&
            User.IsInRole(StaticRoles.Management))
         
            {
                var docs = _doctors.GetDoctors();
                return View(docs);
            }

            return View("AccessDenied");



        }
        //Create
        [Authorize(Roles = StaticRoles.Management)]

        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = StaticRoles.Management)]
        [HttpPost]
        public async Task<IActionResult> Create([Bind
        ("Id,FirstName,LastName,Telephone,EmailAddress,Speciality,Address,RegNumber")]
         Doctor doctor)
        {

            await _doctors.AddDoctor(doctor);
            _doctors.SaveDatabase();
            return RedirectToAction(nameof(Index));

            return View(doctor);
        }
        //Edit

        // GET: Doctor/Edit/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Telephone,EmailAddress,Speciality,Address,RegNumber")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }


            await _doctors.UpdateDoctor(doctor);
            await Task.Run(_doctors.SaveDatabase);
            return RedirectToAction(nameof(Index));

            return View(doctor);
        }

        // GET: Doctor/Delete/5

        [Authorize(Roles = StaticRoles.Management)]
        public async Task<IActionResult> Delete(int? id)
        {
            //if Role is not Management, return access denied
            if (!User.IsInRole(StaticRoles.Management))
            {
                return View("AccessDenied");
            }

            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [Authorize(Roles = StaticRoles.Management)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctors.DeleteDoctor(id);
            await Task.Run(_doctors.SaveDatabase);
            _doctors.SaveDatabase();
            return RedirectToAction(nameof(Index));
        }

        //Details
        [Authorize(Roles = StaticRoles.Doctor + "," + StaticRoles.Management)]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

       //Task that runs for 100s
        [Authorize(Roles = StaticRoles.Doctor + "," + StaticRoles.Management)]
        public async Task<IActionResult> JustTask()
        {
           
            return View();
        }



    }
}

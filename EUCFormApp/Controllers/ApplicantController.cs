using EUCFormApp.Database;
using EUCFormApp.Models;
using EUCFormApp.Models.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EUCFormApp.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Injektuje DB kontext pro přístup k databázi
        /// </summary>
        /// <param name="db"></param>
        public ApplicantController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ApplicantViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApplicantViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Rozparsujeme jmeno a prijmeni (Vzdy pouze 2 slova => jmeno prijmeni)
            var parts = (model.FullName ?? "").Trim().Split(' ');
            var firstName = parts[0];
            var lastName = parts.Length > 1 ? parts[1] : string.Empty;

            // Mapování ViewModel -> Entita pro DB
            var entity = new Applicant
            {
                FirstName = firstName!,
                LastName = lastName!,
                BirthNumber = string.IsNullOrWhiteSpace(model.BirthNumber) ? null : model.BirthNumber!.Trim(),
                DateOfBirth = model.DateOfBirth!.Value, // DOB ve VM je nullable, ale po validaci musí být vyplněné
                Gender = model.Gender,
                Email = model.Email.Trim(),
                Nationality = model.Nationality,
                GdprConsent = model.GdprConsent,
                CreatedAtUtc = DateTime.UtcNow
            };

            // Uložíme do DB
            _db.Applicants.Add(entity);
            await _db.SaveChangesAsync();

            // Vygenerujeme JSON z původních dat formuláře
            var json = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });

            // Cesta do složky /Applications
            var appsDir = Path.Combine(Directory.GetCurrentDirectory(), "Applications");
            if (!Directory.Exists(appsDir))
            {
                Directory.CreateDirectory(appsDir);
            }

            var fileName = $"Applicant-{entity.Id}.json";
            var filePath = Path.Combine(appsDir, fileName);

            await System.IO.File.WriteAllTextAsync(filePath, json);

            // Vrátíme view s potvrzením a cestou k souboru
            ViewBag.JsonPath = filePath;
            return View("Success", model);
        }
    }
}

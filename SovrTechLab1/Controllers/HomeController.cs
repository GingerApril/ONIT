using Laba1Marta.Models;
using Microsoft.AspNetCore.Mvc;
namespace Laba1Marta.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var TableDB = _context.TableDB.ToList();
            return View(TableDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(string name, int number, DateTime BirthDate, DateTime AdmissionDate)
        {
            int id = _context.TableDB.Any() ? _context.TableDB.Max(s => s.ID) + 1 : 1;
            var student = new TableModel
            {
                ID = id,
                Name = name,
                Number = number,
                BirthDate = BirthDate,
                AdmissionDate = AdmissionDate
            };

            _context.TableDB.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.TableDB.FindAsync(id);
            if (student != null)
            {
                _context.TableDB.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Filter(int? ageFrom, int? ageTo, DateTime? admissionBefore, DateTime? admissionAfter)
        {
            var studentsQuery = _context.TableDB.AsQueryable();

            if (ageFrom.HasValue)
            {
                var fromDate = DateTime.Today.AddYears(-ageFrom.Value);
                studentsQuery = studentsQuery.Where(s => s.BirthDate <= fromDate);
            }

            if (ageTo.HasValue)
            {
                var toDate = DateTime.Today.AddYears(-ageTo.Value);
                studentsQuery = studentsQuery.Where(s => s.BirthDate >= toDate);
            }

            if (admissionBefore.HasValue)
            {
                studentsQuery = studentsQuery.Where(s => s.AdmissionDate <= admissionBefore.Value);
            }

            if (admissionAfter.HasValue)
            {
                studentsQuery = studentsQuery.Where(s => s.AdmissionDate >= admissionAfter.Value);
            }

            var filteredStudents = studentsQuery.ToList();

            return View("Index", filteredStudents);
        }
    }

}
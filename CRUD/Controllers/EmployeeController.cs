using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeedbContext _context;
        public EmployeeController(EmployeedbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                _context.Add(e);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(e);
            }
            
        }

        public IActionResult Read()
        {
            List<Employee> data = _context.Employee.ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
           var e = _context.Employee.Where(i => i.ID == id).FirstOrDefault();
           _context.Employee.Remove(e);
           _context.SaveChanges();
            return RedirectToAction(nameof(Read));
        }
        public IActionResult Details(int id)
        {
           var e = _context.Employee.Where(i => i.ID == id).FirstOrDefault();
           return View(e);
        }
        [HttpPost]
        public IActionResult Update(Employee e)
        {
            if (ModelState.IsValid)
            {
                var emp = _context.Employee.Where(i => i.ID == e.ID).FirstOrDefault();
                emp.Name = e.Name;
                emp.Surname = e.Surname;
                emp.Position = e.Position;
                _context.Employee.Update(emp);
                _context.SaveChanges();
                return RedirectToAction(nameof(Read));
            }else
            {
                return View("Details",e);
            }
                         
        }
    }
}

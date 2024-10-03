using Microsoft.AspNetCore.Mvc;
using SpendSmart.Data;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        // new properity for dependency injection
        private readonly SpendSmartDbContext _context;

        // inject the new properity into the constructor
        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();// IActionResult method call and search for Index from View() Views folder // they are connected in the Program.cs app.MapControllerRoute pattern

        public IActionResult Expenses() // the method exactly same name as the View\Home\Expencses.cshtml \\ https://localhost:7141/home/expenses

        {
            var allExpenses = _context.Expenses.ToList(); // without .ToList you will return the Query not the data

            return View(allExpenses);
        }

        public IActionResult CreateEditExpense(int? id) // id can be null on create
        {
            if (id != null) { 
                //Editing so load that entity
                var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id); // find the first occurence of this id
                return View(expenseInDb);
            }

            return View();
        }

        // we will receive the submitted form body
        // we can add model to the Expenses table from the _context since they have the same type of Expense Class
        public IActionResult CreateEditExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
               // Create
                _context.Expenses.Add(model);
            } else
            {
                // Edit
                _context.Expenses.Update(model);
            }

            _context.SaveChanges(); // important

            return RedirectToAction("Expenses");
        }

        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id); // find the first occurence of this id

            if (expenseInDb == null) return NotFound("expense not found");

            _context.Expenses.Remove(expenseInDb); // remove that entity

            _context.SaveChanges();
            return RedirectToAction("Expenses");
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
}

using Microsoft.AspNetCore.Mvc;
using MVC_AjaxFunc.Models;
using System.Diagnostics;
using System.Data.SqlClient;

namespace MVC_AjaxFunc.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        [HttpPost]
        public int Add(int num1 , int num2)
        {
            return num1 + num2;
        }

        public Calculator CalcFunc(long n1, long n2)
        {
            Calculator calc = new Calculator();
            calc.Add = n1 + n2;
            calc.Sub = n1 - n2;
            calc.Mul = n1 * n2;
            calc.Div = (double) (n1/n2);
            return calc;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
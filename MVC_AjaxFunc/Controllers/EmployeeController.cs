using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_AjaxFunc.Data;
using MVC_AjaxFunc.Models;

namespace MVC_AjaxFunc.Controllers
{
    public class EmployeeController : Controller
    {
       
        EmployeeDbContext _db;
        
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HappyFriday;Integrated Security=True");
        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public JsonResult AjaxEmployee(string a, string b, string c, string d)
        {
            Employee emp = new Employee
            {
                EmpName = a,
                Designation = b,
                Address = c,
                Salary = Convert.ToDouble(d)
            };

            //_db.employees.Add(emp);
            //_db.SaveChanges();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into employees (EmpName, Designation, Address, Salary)  values ('" +emp.EmpName+ "' , '" + emp.Designation + "', '" + emp.Address + "', '" + emp.Salary + "')" , conn);
            //SqlCommand cmd = new SqlCommand("insert into employees (EmpName, Designation, Address, Salary)  values (a,b,c,d)", conn);
            cmd.ExecuteNonQuery();
            
            conn.Close();
            return Json(emp);
        }
        public IActionResult Index()
        {
            var empList = _db.employees.ToList();
            return View(empList);
        }
    }
}

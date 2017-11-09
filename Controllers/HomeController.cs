using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sampleReactCS.Controllers{

    class Student {
        public string firstName {get;set;}
        public string lastName{get;set;}

        public Student(string FirstName, string LastName){
            firstName = FirstName;
            lastName = LastName;
        }
        public override string ToString(){
            return firstName + " " + lastName;
        }
    }
    public class HomeController : Controller{
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("api/welcome")]
        public IActionResult Welcome(){
            List<Student> students = new List<Student>();

            students.Add(new Student("Joe", "Shmoe"));
            students.Add(new Student("Jose", "Ortiz"));
            return Json(students);
        }

        

        public IActionResult Error(){
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}

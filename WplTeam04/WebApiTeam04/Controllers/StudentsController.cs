using ClassLibTeam04.Business;
using ClassLibTeam04.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTeam04.Controllers
{
    
   //localhost:41101/api/students api/[controller]          //deze controller is een voorbeeld van Kristof
   [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
       
        [HttpGet]
        public ActionResult Getstudents()
        {
            string jsonResult;
            var dt = Students.GetStudentsDataTable("hassan");
            jsonResult = JsonConvert.SerializeObject(dt);
            return Ok(jsonResult);
        }
        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        { 
            
           var s = Students.AddStudent(student);
            return Ok(s);
        }
    }
}

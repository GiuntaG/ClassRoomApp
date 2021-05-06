using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using ClassroomApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exercises.Services;

namespace Exercises.Controllers
{
    [ApiController]
    [Route("api/Classroom/Student")]
    public class SimplifyFractionController : ControllerBase
    {
        private ISimplifyFractionService _simplifyFractionService; 

        public SimplifyFractionController(ISimplifyFractionService simplifyFractionService)
        {
            _simplifyFractionService = simplifyFractionService;
        }

        

        [HttpPost]
        public ActionResult<bool> AddStudent(Student student)
        {
            if(_simplifyFractionService == null)
            {
                return NotFound();
            }

            var result = _simplifyFractionService.AddStudent(student);

            return result;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<Student>> GetStudents()
        // {
        //     if(_simplifyFractionService == null)
        //     {
        //         return NotFound();
        //     }

        //     var result = _simplifyFractionService.GetAllStudents().ToList();
        //     return result;
        // }

        [HttpGet]
        public ActionResult<string> ReduceFraction(int nbrNumerator = 0, int nbrDenominator = 0)
        {
            if(_simplifyFractionService == null)
            {
                return NotFound();
            }

            var result = _simplifyFractionService.ReduceFraction(nbrNumerator, nbrDenominator);
            return result;
        }

    }

    

    
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudenAdminPortal.Models;
using StudenAdminPortal.Repositery;

namespace StudenAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class StudentsController : ControllerBase
    {
        private IStudentRepositery _StudentRepo;

        public StudentsController(IStudentRepositery studentRepo)
        {
            _StudentRepo = studentRepo;
        }
        [Route("[action]")]  


        public async Task<IActionResult> GetAllStudentsAsync()
        {
            return Ok(await _StudentRepo.GetAllStudentsAsync()); //we are callling the method that we define in the Repos 
        }

         [Route("[action]/{Id:int}")] 


        public async Task<IActionResult> GetStudent(int Id)
        {
            return Ok(await _StudentRepo.GetStudentsAsync(Id)); 
        }
        [HttpPut]
        [Route("[action]/{Id:int}")]
        
        public async Task<IActionResult> UpdateStudent([FromRoute]int Id, [FromBody]UpdateStudent updateStudentmodel )  
        {    
             // from the route we are getting the id 
             /// from the body we are getting the content of Student ,(all the student are the type of the student Model)
       
              var updateStudent = _StudentRepo.UpdateStudent(Id, updateStudentmodel); // we are passing the id and the student that is coming from the front end 
                if (updateStudent!=null) //
                {
                    return Ok(updateStudent); 
                
                }
            
               return NotFound();
                
        }

    }
}

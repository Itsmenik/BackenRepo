using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudenAdminPortal.Repositery;

namespace StudenAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {

        private IStudentRepositery _StudentRepo;

        public GenderController(IStudentRepositery studentRepo)
        {
            _StudentRepo = studentRepo;
        }
        [Route("[action]")]

        public async Task<IActionResult> GetGendersAsync()
        {
            return Ok(await _StudentRepo.GetGendersAsync()); // we are callling the method that we define in the Repos 
        }
    }
}

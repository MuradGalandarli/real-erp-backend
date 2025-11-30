using Microsoft.AspNetCore.Mvc;

namespace RealERP.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet("get-all-employee")]
        //public async Task<IActionResult> GetALLEmployee([FromBody] GetAllEm)


    }
}

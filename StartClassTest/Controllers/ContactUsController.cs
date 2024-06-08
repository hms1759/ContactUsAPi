using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartClassTest.IServices;
using StartClassTest.ViewModel;

namespace StartClassTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> ContactUs([FromBody] ContactUsViewModel booking)
        {
          var result = await  _contactUsService.CreateContactus(booking);
            if(result)
                return Ok("Contact us successfully submitted");

            return BadRequest("Error occur while trying to send email");
        }
    }
}

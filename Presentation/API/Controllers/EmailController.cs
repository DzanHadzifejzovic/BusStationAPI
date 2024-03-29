using Application.DTOs.Email;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailService;

        public EmailController(IEmailSender emailService)
        {
            _emailService = emailService;
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmailAsync(request.To,request.Subject,request.Body);
            return Ok();
        }
    }
}

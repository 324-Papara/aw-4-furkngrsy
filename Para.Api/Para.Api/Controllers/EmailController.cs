using Microsoft.AspNetCore.Mvc;
using Para.Api.Services;

namespace Para.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailQueueService _emailQueueService;

        public EmailController(EmailQueueService emailQueueService)
        {
            _emailQueueService = emailQueueService;
        }

        [HttpPost]
        [Route("queue")]
        public IActionResult QueueEmail(string email)
        {
            _emailQueueService.QueueEmail(email);
            return Ok("Email queued successfully.");
        }
    }
}

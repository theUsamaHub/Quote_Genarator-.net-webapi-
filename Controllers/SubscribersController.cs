using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quote_genarator.Data;

namespace Quote_genarator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public SubscribersController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quote_genarator.Data;
using Quote_genarator.Models;

namespace Quote_generator.Controllers
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

        // =========================
        // Subscribe (Send Confirmation Email)
        // =========================
        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody] string email)
        {
            // Check if email already exists
            var existing = await _context.Subscribers
                .FirstOrDefaultAsync(x => x.Email == email);

            if (existing != null)
                return BadRequest("Email already exists");

            // Generate unique token for email verification
            var token = Guid.NewGuid().ToString();

            var subscriber = new Subscriber
            {
                Email = email,
                ConfirmationToken = token,
                IsSubscribed = false,
                IsConfirmed = false,
                SubscribedAt = DateTime.UtcNow
            };

            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();

            // Confirmation link sent to user email
            var confirmLink = $"https://yourdomain.com/api/subscribers/confirm?token={token}";

            await _emailService.SendAsync(
                email,
                "Confirm Subscription",
                $"Click to confirm your subscription:\n{confirmLink}"
            );

            return Ok("Confirmation email sent");
        }

        // =========================
        // Confirm Email (Activate Subscription)
        // =========================
        [HttpGet("confirm")]
        public async Task<IActionResult> Confirm(string token)
        {
            var subscriber = await _context.Subscribers
                .FirstOrDefaultAsync(x => x.ConfirmationToken == token);

            if (subscriber == null)
                return BadRequest("Invalid token");

            // Activate subscription
            subscriber.IsConfirmed = true;
            subscriber.IsSubscribed = true;

            await _context.SaveChangesAsync();

            return Ok("Subscription confirmed");
        }

        // =========================
        // Unsubscribe (Soft Delete)
        // =========================
        [HttpDelete("{email}")]
        public async Task<IActionResult> Unsubscribe(string email)
        {
            var subscriber = await _context.Subscribers
                .FirstOrDefaultAsync(x => x.Email == email);

            if (subscriber == null)
                return NotFound();

            // Disable subscription instead of deleting
            subscriber.IsSubscribed = false;

            await _context.SaveChangesAsync();

            return Ok("Unsubscribed successfully");
        }

        // =========================
        // Update Email (Re-confirm Required)
        // =========================
        [HttpPut]
        public async Task<IActionResult> UpdateEmail(string oldEmail, string newEmail)
        {
            var subscriber = await _context.Subscribers
                .FirstOrDefaultAsync(x => x.Email == oldEmail);

            if (subscriber == null)
                return NotFound();

            // Update email and reset verification
            subscriber.Email = newEmail;
            subscriber.IsConfirmed = false;
            subscriber.IsSubscribed = false;
            subscriber.ConfirmationToken = Guid.NewGuid().ToString();

            await _context.SaveChangesAsync();

            // Send new confirmation email
            var confirmLink = $"https://yourdomain.com/api/subscribers/confirm?token={subscriber.ConfirmationToken}";

            await _emailService.SendAsync(
                newEmail,
                "Confirm New Email",
                $"Click to confirm your new email:\n{confirmLink}"
            );

            return Ok("Please confirm your new email");
        }

        // =========================
        // Get All Subscribers (Admin Purpose)
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscribers = await _context.Subscribers.ToListAsync();
            return Ok(subscribers);
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User")]
    public class ContactController : Controller
    {
        private ISupportTicketRepository _supportTicketRepository;
        private UserManager<ApplicationUser> _userManager;
        private ILogger<ContactController> _logger;
        public ContactController(ISupportTicketRepository supportTicketRepository,UserManager<ApplicationUser> userManager ,ILogger<ContactController> logger)
        {
            _supportTicketRepository = supportTicketRepository;
            _userManager = userManager;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendTicket(string userId, string subject, string message)
        {
            var newTicket = new SupportTicket
            {
                SenderId = userId,
                Subject = subject,
                isResolved = false,
                SentAt = DateTime.Now,
                Messages = new List<SupportTicketMessage>
                {
                    new SupportTicketMessage
                    {
                        SenderId = userId,
                        Content = message,
                        IsFromAdmin = false,
                        SentAt = DateTime.Now
                    }
                }
            };

            _logger.LogInformation("POSTAVLJEN DATUM ZA TIKET" + newTicket.Messages[0].SentAt.ToString());

            try
            {
                await _supportTicketRepository.AddTicket(newTicket);
                await _supportTicketRepository.Save();

                TempData["SuccessMessage"] = "Tiket je uspešno poslat. Odgovor stiže u najkraćem mogućem roku";
                return View("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("Došlo je do greške: " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom slanja tiketa, pokušajte ponovo kasnije";
                return View("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> UserTickets()
        {
            var userId = _userManager.GetUserId(User);
            var tickets = _supportTicketRepository.GetUserTicket(userId!);

            var userTickets = await tickets.ToListAsync();

            return View(userTickets);

        }

        [HttpGet]
        public async Task<IActionResult> TicketDetails(int id)
        {


            var ticket = await _supportTicketRepository.Get(id);

            if(ticket == null)
            {
                TempData["ErrorMessage"] = "Tiket nije pronadjen, pokušajte ponovo kasnije...";
                return View("UserTickets");
            }

            var userTicket = new TicketDetailsViewModel
            {
                Id = ticket.Id,
                Title = ticket.Subject,
                IsResolved = ticket.isResolved,
                Messages = ticket.Messages
                .OrderBy(m => m.SentAt)
                .Select(m => new TicketMessageVm
                {
                    IsFromAdmin = m.IsFromAdmin,
                    Content = m.Content,
                    SentAt = m.SentAt,
                }).ToList()

            };
            return View(userTicket);
        }

        public async Task<IActionResult> SendMessage(string message, int ticketId)
        {

            var userId = _userManager.GetUserId(User);

            var newMessage = new SupportTicketMessage
            {
                SenderId = userId!,
                Content = message,
                IsFromAdmin = false,
                SentAt = DateTime.Now,
                TicketId = ticketId
            };

            try
            {
                await _supportTicketRepository.AddMessage(newMessage);
                await _supportTicketRepository.Save();
                return RedirectToAction("TicketDetails", new { id = ticketId });
               
            }
            catch (Exception ex)
            {
                _logger.LogError("GREŠKA PRILIKOM SLANJA TIKETA: " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilkom slanja poruke, pokušajte ponovo kasnije";
                return RedirectToAction("TicketDetails", new { id = ticketId });
            }


        }

        [HttpPost]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _supportTicketRepository.Get(id);

            if (ticket == null) return NotFound();

            try
            {
                await _supportTicketRepository.Delete(ticket);
                await _supportTicketRepository.Save();
                TempData["SuccessMessage"] = "Tiket je uspešno obrisan";
                return RedirectToAction("UserTickets");
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA PRILIKOM BRISANJA TIKETA: " + ex);
    
                TempData["ErrorMessage"] = "Došlo je do greške prilkom brisanja tiketa, pokušajte ponovo kasnije";
                return RedirectToAction("TicketDetails", new { id  });
            }

        }


    }

}

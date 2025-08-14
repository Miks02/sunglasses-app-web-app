using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Controllers;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;

namespace SunglassesApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TicketController : Controller
    {
        private ISupportTicketRepository _supportTicketRepository;
        private UserManager<ApplicationUser> _userManager;
        private ILogger<TicketController> _logger;
        public TicketController(ISupportTicketRepository supportTicketRepository,UserManager<ApplicationUser> userManager ,ILogger<TicketController> logger)
        {
            _supportTicketRepository = supportTicketRepository; 
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _supportTicketRepository.GetAll().ToListAsync();

            return View(tickets);
        }

        [HttpGet]
        public async Task<IActionResult> TicketDetails(int id)
        {
            var ticket = await _supportTicketRepository.Get(id);


            if (ticket == null)
            {
                TempData["ErrorMessage"] = "Tiket nije pronadjen, pokušajte ponovo kasnije...";
                return View("UserTickets");
            }

            var userTicket = new TicketDetailsViewModel
            {
                Id = ticket.Id,
                Title = ticket.Subject,
                IsResolved = ticket.isResolved,
                Sender = ticket.Sender,
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

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message, int ticketId)
        {

            var userId = _userManager.GetUserId(User);

            var newMessage = new SupportTicketMessage
            {
                SenderId = userId!,
                Content = message,
                IsFromAdmin = true,
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
                TempData["ErrorMessage"] = "Došlo je do greške prilikom slanja poruke, pokušajte ponovo kasnije";
                return RedirectToAction("TicketDetails", new { id = ticketId });
            }


        }

        [HttpPost]
        public async Task<IActionResult> MarkAsResolved(int id)
        {
            var ticket = await _supportTicketRepository.Get(id);

            if (ticket == null)
            {
                TempData["ErrorMessage"] = "Došlo je do greške prilikom zatvaranja tiketa, pokušajte ponovo kasnije";
                return RedirectToAction("TicketDetails", new { id });
            }

            try
            {
                await _supportTicketRepository.Resolve(ticket);
                await _supportTicketRepository.Save();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA: " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom zatvaranja tiketa, pokušajte ponovo kasnije";
                return RedirectToAction("TicketDetails", new { id });
            }

        }

    }
}

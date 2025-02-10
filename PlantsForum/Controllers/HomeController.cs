using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantsForum.Models;
using PlantsForum.Data;
using System.Diagnostics;

namespace PlantsForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlantsForumContext _context;

        // Constructor to inject DbContext
        public HomeController(ILogger<HomeController> logger, PlantsForumContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Home/Index
        public async Task<IActionResult> Index()
        {
            var discussions = await _context.Discussion
                .OrderByDescending(d => d.CreateDate) // Order by CreateDate desc.
                .Include(d => d.Comment)  // Include the comments 
                .ToListAsync();

            return View(discussions);
        }

        // GET: Home/GetDiscussion/5
        public async Task<IActionResult> GetDiscussion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussion = await _context.Discussion
                .Include(d => d.Comment)  // Include comments //The relationship between the cmts and discussion is one to many
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            // Ensure comments are sorted in descending order by CreateDate
            discussion.Comment = discussion.Comment.OrderByDescending(c => c.CreateDate).ToList();

            return View(discussion);
        }

    }
}
        
    

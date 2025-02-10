using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlantsForum.Data;
using PlantsForum.Models;

namespace PlantsForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly PlantsForumContext _context;

        public CommentsController(PlantsForumContext context)
        {
            _context = context;
        }

        // GET: Comments/Create
        public IActionResult Create(int discussionId)
        {
            ViewBag.DiscussionId = discussionId;
            return View(new Comment { DiscussionId = discussionId });
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,DiscussionId,CreateDate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                // Set the CreateDate and DiscussionId 
                comment.CreateDate = DateTime.Now;

                // Add the comment to the context
                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Redirect back to the discussion page 
                return RedirectToAction("GetDiscussion", "Home", new { id = comment.DiscussionId });
            }

            // 
            return View(comment);
        }
        // Deleted CRUD actions:

        // GET: Comments/Edit/5
        // POST: Comments/Edit/5
        // GET: Comments/Delete/5
        // GET: Comments
        // GET: Comments/Details/5
        // POST: Comments/Delete/5
    }
}

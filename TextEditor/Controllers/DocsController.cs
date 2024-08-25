using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TextEditor.Data;
using TextEditor.Models;

namespace TextEditor.Controllers
{
    [Authorize]
    public class DocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Docs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Docs.Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Docs/Details/5
        
        // GET: Docs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Docs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,UserId")] Doc doc)
        {
            // Get the logged-in user's ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            doc.UserId = userId;
            doc.User = await _context.Users.FindAsync(userId);


            if (string.IsNullOrEmpty(doc.UserId))
            {
                ModelState.AddModelError(string.Empty, "User is not logged in.");
                return View(doc);
            }

            

            

            if (ModelState.IsValid)
            {
                // Add the document to the context and save changes
                _context.Add(doc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Log validation errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(doc);
        }




        // GET: Docs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doc = await _context.Docs.FindAsync(id);
            if (doc == null)
            {
                return NotFound();
            }
            if (doc.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }
            return View(doc);
        }

        // POST: Docs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Content,UserId")] Doc doc)
        {
            if (id != doc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocExists(doc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", doc.UserId);
            return View(doc);
        }

        // GET: Docs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doc = await _context.Docs
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doc == null)
            {
                return NotFound();
            }
            if (doc.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return NotFound();
            }

            return View(doc);
        }

        // POST: Docs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doc = await _context.Docs.FindAsync(id);
            if (doc != null)
            {
                _context.Docs.Remove(doc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocExists(string id)
        {
            return _context.Docs.Any(e => e.Id == id);
        }
    }
}

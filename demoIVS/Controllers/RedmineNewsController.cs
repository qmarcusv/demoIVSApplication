 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demoIVS.Data;
using demoIVS.Models;
using Microsoft.AspNetCore.Authorization;

namespace demoIVS.Controllers
{
    public class RedmineNewsController : Controller
    {
        private readonly RedmineNewsDB _context;

        public RedmineNewsController(RedmineNewsDB context)
        {
            _context = context;
        }
        [Authorize]
        // GET: RedmineNews
        public async Task<IActionResult> Index()
        {
            return View(await _context.RedmineNews.ToListAsync());
        }
        [Authorize]

        // GET: RedmineNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redmineNews = await _context.RedmineNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redmineNews == null)
            {
                return NotFound();
            }

            return View(redmineNews);
        }
        [Authorize]

        // GET: RedmineNews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RedmineNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Title,Summary,Description")] RedmineNews redmineNews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(redmineNews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(redmineNews);
        }
        [Authorize]

        // GET: RedmineNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redmineNews = await _context.RedmineNews.FindAsync(id);
            if (redmineNews == null)
            {
                return NotFound();
            }
            return View(redmineNews);
        }
        [Authorize]

        // POST: RedmineNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Title,Summary,Description")] RedmineNews redmineNews)
        {
            if (id != redmineNews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(redmineNews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedmineNewsExists(redmineNews.Id))
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
            return View(redmineNews);
        }
        [Authorize]

        // GET: RedmineNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var redmineNews = await _context.RedmineNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redmineNews == null)
            {
                return NotFound();
            }

            return View(redmineNews);
        }
        [Authorize]

        // POST: RedmineNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var redmineNews = await _context.RedmineNews.FindAsync(id);
            if (redmineNews != null)
            {
                _context.RedmineNews.Remove(redmineNews);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RedmineNewsExists(int id)
        {
            return _context.RedmineNews.Any(e => e.Id == id);
        }
    }
}

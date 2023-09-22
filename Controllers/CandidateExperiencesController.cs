using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vindovino_candidates.Database;
using vindovino_candidates.Models;

namespace vindovino_candidates.Controllers
{
    public class CandidateExperiencesController : Controller
    {
        private readonly ValendbContext _context;

        public CandidateExperiencesController(ValendbContext context)
        {
            _context = context;
        }

        // GET: CandidateExperiences
        public async Task<IActionResult> Index()
        {
            var valendbContext = _context.Candidateexperiences.Include(c => c.IdCandidateNavigation);
            return View(await valendbContext.ToListAsync());
        }

        // GET: CandidateExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidateexperiences == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.Candidateexperiences
                .Include(c => c.IdCandidateNavigation)
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateexperience == null)
            {
                return NotFound();
            }

            return View(candidateexperience);
        }

        // GET: CandidateExperiences/Create
        public IActionResult Create()
        {
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "IdCandidate", "IdCandidate");
            return View();
        }

        // POST: CandidateExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidateExperience,IdCandidate,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] Candidateexperience candidateexperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateexperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "IdCandidate", "IdCandidate", candidateexperience.IdCandidate);
            return View(candidateexperience);
        }

        // GET: CandidateExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidateexperiences == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.Candidateexperiences.FindAsync(id);
            if (candidateexperience == null)
            {
                return NotFound();
            }
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "IdCandidate", "IdCandidate", candidateexperience.IdCandidate);
            return View(candidateexperience);
        }

        // POST: CandidateExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCandidateExperience,IdCandidate,Company,Job,Description,Salary,BeginDate,EndDate,InsertDate,ModifyDate")] Candidateexperience candidateexperience)
        {
            if (id != candidateexperience.IdCandidateExperience)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateexperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateexperienceExists(candidateexperience.IdCandidateExperience))
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
            ViewData["IdCandidate"] = new SelectList(_context.Candidates, "IdCandidate", "IdCandidate", candidateexperience.IdCandidate);
            return View(candidateexperience);
        }

        // GET: CandidateExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidateexperiences == null)
            {
                return NotFound();
            }

            var candidateexperience = await _context.Candidateexperiences
                .Include(c => c.IdCandidateNavigation)
                .FirstOrDefaultAsync(m => m.IdCandidateExperience == id);
            if (candidateexperience == null)
            {
                return NotFound();
            }

            return View(candidateexperience);
        }

        // POST: CandidateExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidateexperiences == null)
            {
                return Problem("Entity set 'ValendbContext.Candidateexperiences'  is null.");
            }
            var candidateexperience = await _context.Candidateexperiences.FindAsync(id);
            if (candidateexperience != null)
            {
                _context.Candidateexperiences.Remove(candidateexperience);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateexperienceExists(int id)
        {
          return (_context.Candidateexperiences?.Any(e => e.IdCandidateExperience == id)).GetValueOrDefault();
        }
    }
}

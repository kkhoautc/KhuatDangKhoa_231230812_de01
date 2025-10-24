using System.Diagnostics;
using KhuatDangKhoa_231230812_de01.Models;
using Microsoft.AspNetCore.Mvc;
using KhuatDangKhoa_231230812_de01.Data;
using Microsoft.EntityFrameworkCore;

namespace KhuatDangKhoa_231230812_de01.Controllers
{
    public class kdkHomeController : Controller
    {
        private readonly ILogger<kdkHomeController> _logger;
        private KhuatDangKhoa231230812De01Context _context = new KhuatDangKhoa231230812De01Context();

        public kdkHomeController(ILogger<kdkHomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> kdkCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> kdkCreate(KdkComputer kdkComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kdkComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(kdkIndex));
            }
            return View(kdkComputer);
        }




        public IActionResult kdkIndex()
        {
            var kdk = _context.KdkComputers.ToList();
            return View(kdk);
        }

        public async Task<IActionResult> kdkDetails(int? id)
        {
            if (id == null || _context.KdkComputers == null)
            {
                return NotFound();
            }
            var kdkComputer = await _context.KdkComputers
                .FirstOrDefaultAsync(m => m.KdkComId == id);
            if (kdkComputer == null)
            {
                return NotFound();
            }
            return View(kdkComputer);
        }

        public async Task<IActionResult> kdkDelete(int? id)
        {
            if (id == null || _context.KdkComputers == null)
            {
                return NotFound();
            }
            var kdkComputer = await _context.KdkComputers
                .FirstOrDefaultAsync(m => m.KdkComId == id);
            if (kdkComputer == null)
            {
                return NotFound();
            }
            return View(kdkComputer);
        }
        [HttpPost, ActionName("kdkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> kdkDeleteConfirmed(int id)
        {
            if (_context.KdkComputers == null)
            {
                return Problem("Entity set 'KhuatDangKhoa231230812De01Context.KdkComputers'  is null.");
            }
            var kdkComputer = await _context.KdkComputers.FindAsync(id);
            if (kdkComputer != null)
            {
                _context.KdkComputers.Remove(kdkComputer);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(kdkIndex));
        }

        public async Task<IActionResult> kdkEdit(int? id)
        {
            if (id == null || _context.KdkComputers == null)
            {
                return NotFound();
            }
            var kdkComputer = await _context.KdkComputers.FindAsync(id);
            if (kdkComputer == null)
            {
                return NotFound();
            }
            return View(kdkComputer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> kdkEdit(int id, KdkComputer kdkComputer)
        {
            if (id != kdkComputer.KdkComId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kdkComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KdkComputerExists(kdkComputer.KdkComId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(kdkIndex));
            }
            return View(kdkComputer);
        }

        public bool KdkComputerExists(int id)
        {
            return _context.KdkComputers.Any(e => e.KdkComId == id);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

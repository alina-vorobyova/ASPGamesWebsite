using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamesSearchAsp.Models;
using Microsoft.AspNetCore.Http;
using GamesSearchAsp.Helpers;
using GamesSearchAsp.Areas.Admin.Helpers;

namespace GamesSearchAsp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameProductsController : Controller
    {
        private readonly GameAppDbContext _context;

        public GameProductsController(GameAppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GameProducts
        public async Task<IActionResult> Index()
        {
            var gameAppDbContext = _context.GameProducts.Include(g => g.GamePlatform);
            return View(await gameAppDbContext.ToListAsync());
        }

        // GET: Admin/GameProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameProduct = await _context.GameProducts
                .Include(g => g.GamePlatform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameProduct == null)
            {
                return NotFound();
            }

            return View(gameProduct);
        }

        // GET: Admin/GameProducts/Create
        public IActionResult Create()
        {
            ViewData["GamePlatformId"] = new SelectList(_context.GamePlatforms, "Id", "PlatformName");
            return View();
        }

        // POST: Admin/GameProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GameProduct gameProduct, IFormFile uploadImg, string url)
        {
            try
            {
                if (uploadImg != null)
                {
                    var path = await FileUploadHelper.UploadFile(uploadImg);
                    gameProduct.Image = path;
                    if (ModelState.IsValid)
                    {
                        _context.GameProducts.Add(gameProduct);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        var path = await ImageLoader.DownloadFile(url);
                        gameProduct.Image = path;
                        _context.GameProducts.Add(gameProduct);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch (Exception)
            {
                TempData["LinkError"] = "Invalid link";
            }
            ViewData["GamePlatformId"] = new SelectList(_context.GamePlatforms, "Id", "PlatformName", gameProduct.GamePlatformId);
            return View(gameProduct);
        }

        // GET: Admin/GameProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameProduct = await _context.GameProducts.FindAsync(id);
            if (gameProduct == null)
            {
                return NotFound();
            }
            ViewData["GamePlatformId"] = new SelectList(_context.GamePlatforms, "Id", "PlatformName", gameProduct.GamePlatformId);
            return View(gameProduct);
        }

        // POST: Admin/GameProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GameProduct gameProduct, IFormFile uploadImg, string url)
        {
            if (id != gameProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (uploadImg != null)
                    {
                        var path = await FileUploadHelper.UploadFile(uploadImg);
                        gameProduct.Image = path;
                        if (ModelState.IsValid)
                        {
                            _context.GameProducts.Update(gameProduct);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        if (ModelState.IsValid)
                        {
                            var path = await ImageLoader.DownloadFile(url);
                            gameProduct.Image = path;
                            _context.GameProducts.Update(gameProduct);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameProductExists(gameProduct.Id))
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
            ViewData["GamePlatformId"] = new SelectList(_context.GamePlatforms, "Id", "PlatfromName", gameProduct.GamePlatformId);
            return View(gameProduct);
        }

        // GET: Admin/GameProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameProduct = await _context.GameProducts
                .Include(g => g.GamePlatform)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameProduct == null)
            {
                return NotFound();
            }

            return View(gameProduct);
        }

        // POST: Admin/GameProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameProduct = await _context.GameProducts.FindAsync(id);
            _context.GameProducts.Remove(gameProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameProductExists(int id)
        {
            return _context.GameProducts.Any(e => e.Id == id);
        }
    }
}

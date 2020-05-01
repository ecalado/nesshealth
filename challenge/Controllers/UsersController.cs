using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using challenge.Data;
using challenge.Models;
using System.Diagnostics;
using System.Linq.Expressions;
using Challenge.Persistence;

namespace challenge.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ChallengeContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        // GET: Users
        public async Task<IActionResult> Index(string sortBy, string orderedBy)
        {
            ViewData["OrderedByNameParm"] = String.IsNullOrEmpty(orderedBy) ? "desc" : "";
            ViewData["OrderedByCPFParm"] = String.IsNullOrEmpty(orderedBy) ? "desc" : "";
           
            return View(await _unitOfWork.Users.GetAllPageable(sortBy, orderedBy));
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.Users.Get(id.GetValueOrDefault());

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CPF,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Users.Add(user);
                    await _unitOfWork.Complete();
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("userExists", ex.Message);

                    return View(user);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.Users.Get(id.GetValueOrDefault());

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CPF,PhoneNumber")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Users.Update(user);
                    await _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_unitOfWork.Users.Exists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                } catch (ArgumentException ex)
                {
                    ModelState.AddModelError("userExists", ex.Message);

                    return View(user);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.Users.Get(id.GetValueOrDefault());

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _unitOfWork.Users.Get(id);

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

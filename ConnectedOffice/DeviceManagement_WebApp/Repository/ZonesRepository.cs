using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository
    {
        private readonly ConnectedOfficeContext _officeContext = new ConnectedOfficeContext();

        public List<Zone> GetAll()
        {
            return _officeContext.Zone.ToList();
        }
        //GET: Zones/Details/5
        public async Task<Zone> GetById(Guid? id)
        {
            var zone = await _officeContext.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);
            return (zone);
        }
        // POST: Zones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _officeContext.Add(zone);
            await _officeContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Zones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = await _officeContext.Zone.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }
            return View(zone);
        }

        // POST: Zones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return NotFound();
            }

            try
            {
                _officeContext.Update(zone);
                await _officeContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(zone.ZoneId))
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

        // GET: Zones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var zone = await _officeContext.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // POST: Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var zone = await _officeContext.Zone.FindAsync(id);
            _officeContext.Zone.Remove(zone);
            await _officeContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZoneExists(Guid id)
        {
            return _officeContext.Zone.Any(e => e.ZoneId == id);
        }
    }
}

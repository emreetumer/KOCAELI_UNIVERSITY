﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvrakTakip.Data;
using EvrakTakip.Models;
using Microsoft.AspNetCore.Authorization;
using EvrakTakip.Utility;

namespace EvrakTakip.Pages.EvrakTipleri
{
    [Authorize(Roles = StatikRoller.AdminKullanici)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EvrakTipi EvrakTipi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EvrakTipi = await _db.EvrakTipi.FirstOrDefaultAsync(m => m.Id == id);

            if (EvrakTipi == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var BakimFromDb = await _db.EvrakTipi.FirstOrDefaultAsync(a => a.Id == EvrakTipi.Id);
            BakimFromDb.EvrakAdi = EvrakTipi.EvrakAdi;
            BakimFromDb.EvrakFiyati = EvrakTipi.EvrakFiyati;

            await _db.SaveChangesAsync();


            return RedirectToPage("./Index");
        }


    }
}

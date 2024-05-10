﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cafe.Models;
using RazorPagesDemo.Data;

namespace RazorPagesDemo.Pages.Nomenclatures
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDemo.Data.ApplicationDbContext _context;

        public DetailsModel(RazorPagesDemo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Nomenclature Nomenclature { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomenclature = await _context.Nomenclature.FirstOrDefaultAsync(m => m.Id == id);
            if (nomenclature == null)
            {
                return NotFound();
            }
            else
            {
                Nomenclature = nomenclature;
            }
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab12.Data;
using lab12.Models;

namespace lab12.Pages.Scholarships
{
    public class DetailsModel : PageModel
    {
        private readonly lab12.Data.lab12Contex _context;

        public DetailsModel(lab12.Data.lab12Contex context)
        {
            _context = context;
        }

      public Scholarship Scholarship { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scholarship == null)
            {
                return NotFound();
            }

            var scholarship = await _context.Scholarship.FirstOrDefaultAsync(m => m.StipId == id);
            if (scholarship == null)
            {
                return NotFound();
            }
            else 
            {
                Scholarship = scholarship;
            }
            return Page();
        }
    }
}
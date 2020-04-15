using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using schools_identity.Data;
using schools_identity.Model;
using Microsoft.AspNetCore.Authorization;

namespace schools_identity.Pages.dbcrud
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly schools_identity.Data.listDbContext _context;

        public EditModel(schools_identity.Data.listDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public list list { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            list = await _context.list.FirstOrDefaultAsync(m => m.Id == id);

            if (list == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(list).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!listExists(list.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool listExists(long id)
        {
            return _context.list.Any(e => e.Id == id);
        }
    }
}

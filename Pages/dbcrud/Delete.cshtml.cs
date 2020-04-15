using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using schools_identity.Data;
using schools_identity.Model;
using Microsoft.AspNetCore.Authorization;

namespace schools_identity.Pages.dbcrud
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly schools_identity.Data.listDbContext _context;

        public DeleteModel(schools_identity.Data.listDbContext context)
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            list = await _context.list.FindAsync(id);

            if (list != null)
            {
                _context.list.Remove(list);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

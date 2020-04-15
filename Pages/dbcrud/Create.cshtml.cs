using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using schools_identity.Data;
using schools_identity.Model;
using Microsoft.AspNetCore.Authorization;

namespace schools_identity.Pages.dbcrud
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly schools_identity.Data.listDbContext _context;

        public CreateModel(schools_identity.Data.listDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public list list { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.list.Add(list);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

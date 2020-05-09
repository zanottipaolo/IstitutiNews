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
using Microsoft.EntityFrameworkCore;

namespace schools_identity.Pages.dbcrud
{
    [Microsoft.AspNetCore.Authorization.Authorize]
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
            string NewSchool_Name = list.name.ToLower();
            string NewSchool_Address = list.address.ToLower();
            var Check_Name = await _context.list.Where(m => m.name.ToLower() == NewSchool_Name.ToLower()).ToListAsync();
            var Check_Address = await _context.list.Where(m => m.address.ToLower() == NewSchool_Address.ToLower()).ToListAsync();


            if (Check_Name.Count > 0 && Check_Address.Count > 0)
            {
                if (Check_Name[0].name.ToLower().ToString() == NewSchool_Name && Check_Address[0].address.ToLower().ToString() == NewSchool_Address)
                    return BadRequest(new { ErrorMessage = "This school is already registered" });
            }

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

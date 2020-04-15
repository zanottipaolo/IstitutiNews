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
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly schools_identity.Data.listDbContext _context;

        [BindProperty]
        public string filter_name { set; get; }

        [BindProperty]
        public string filter_city { set; get; }

        [BindProperty]
        public string filter_address { set; get; }

        [BindProperty]
        public string filter_headmaster { set; get; }

        [BindProperty]
        public string filter_courses { set; get; }

        public IndexModel(schools_identity.Data.listDbContext context)
        {
            _context = context;
        }

        public IList<list> list { get;set; }

        public async Task OnGetAsync()
        {
            list = await _context.list.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string filter_name, string filter_city, string filter_address, string filter_headmaster, string courses)
        {
            if (filter_name == null && filter_city == null && filter_address == null && filter_headmaster == null && filter_courses == null)
            {
                list = await _context.list.ToListAsync();
            }
            else
            {
                list = await _context.list.Where(m => m.name == filter_name && m.city == filter_city && m.address == filter_address && m.headmaster == filter_headmaster && m.courses == filter_courses).ToListAsync();
            }

            return Page();
        }
    }
}

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
        private readonly listDbContext _context;

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

        public IndexModel(listDbContext context)
        {
            _context = context;
        }

        public IList<list> list { get;set; }

        public async Task OnGetAsync()
        {
            list = await _context.list.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string filter_name, string filter_city, string filter_address, string filter_headmaster, string filter_courses)
        {
            var List_Search = await _context.list.ToListAsync();

            if (filter_name == null && filter_city == null && filter_address == null && filter_headmaster == null && filter_courses == null)
                List_Search = await _context.list.ToListAsync();

            if (!string.IsNullOrEmpty(filter_name))
                List_Search = List_Search.Where(m => m.name.ToLower().Contains(filter_name.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter_city))
                List_Search = List_Search.Where(m => m.city.ToLower().Contains(filter_city.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter_address))
                List_Search = List_Search.Where(m => m.address.ToLower().Contains(filter_address.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter_headmaster))
                List_Search = List_Search.Where(m => m.headmaster.ToLower().Contains(filter_headmaster.ToLower())).ToList();

            if (!string.IsNullOrEmpty(filter_courses))
                List_Search = List_Search.Where(m => m.courses.ToLower().Contains(filter_courses.ToLower())).ToList();

            list = List_Search;

            return Page();
        }
    }
}

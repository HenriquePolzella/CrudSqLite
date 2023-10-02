using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TesteHenrique.Data;
using TesteHenrique.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace TesteHenrique.Pages.Premiums
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Premium Premium { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premium> Premiums { get; set; }

        public async Task OnGetAsync()
        {
            Premiums = await _context.Premiums
                .Include(p => p.Student)
                .ToListAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TesteHenrique.Data;
using TesteHenrique.Models;
using System.Threading.Tasks;

namespace TesteHenrique.Pages.Premiums
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Premium = await _context.Premiums
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Premium == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var premium = await _context.Premiums.FindAsync(Premium.Id);

            if (premium != null)
            {
                _context.Premiums.Remove(premium);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

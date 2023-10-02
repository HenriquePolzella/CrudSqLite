using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteHenrique.Data;
using TesteHenrique.Models;

namespace TesteHenrique.Pages.Premiums
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; }

        public SelectList StudentSelectList { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Premium = await _context.Premiums.FindAsync(id);

            if (Premium == null)
            {
                return NotFound();
            }

            PopulateStudentSelectList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateStudentSelectList();
                return Page();
            }

            _context.Attach(Premium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Premiums.Any(e => e.Id == Premium.Id))
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

        private void PopulateStudentSelectList()
        {
            StudentSelectList = new SelectList(_context.Students, "Id", "Name", Premium.StudentId);
        }
    }
}

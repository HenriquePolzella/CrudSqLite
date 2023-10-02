using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TesteHenrique.Data;
using TesteHenrique.Models;

namespace TesteHenrique.Pages.Premiums
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Premium Premium { get; set; }

        public List<SelectListItem> StudentSelectList { get; private set; }

        public void OnGet()
        {
            PopulateStudentSelectList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                PopulateStudentSelectList();
                return Page();
            }

            _context.Premiums.Add(Premium);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

        private void PopulateStudentSelectList()
        {
            StudentSelectList = _context.Students
                .Select(student => new SelectListItem
                {
                    Value = student.Id.ToString(),
                    Text = $"{student.Name} (ID: {student.Id})"
                })
                .ToList();
        }
    }
}

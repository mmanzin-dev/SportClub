using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportClub.Models;

namespace SportClub.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly SportClubDbContext _context;

        public CreateModel(SportClubDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TeamId"] = new SelectList(_context.Set<Team>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

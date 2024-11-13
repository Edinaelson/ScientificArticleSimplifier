using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScientificArticleSimplifier.Data;
using ScientificArticleSimplifier.Models;
using ScientificArticleSimplifier.Services;

namespace ScientificArticleSimplifier.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly ScientificArticleSimplifier.Data.ApplicationDbContext _context;

        public CreateModel(ScientificArticleSimplifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RequestId"] = new SelectList(_context.Requests, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnGetGemini(string text)
        {
            var result = await LlmServices.GenerateContentAsync(text);

            return new JsonResult( new { result });
        }

        [BindProperty]
        public Post Post { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Posts.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

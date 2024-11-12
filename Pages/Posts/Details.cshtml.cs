using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScientificArticleSimplifier.Data;
using ScientificArticleSimplifier.Models;

namespace ScientificArticleSimplifier.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly ScientificArticleSimplifier.Data.ApplicationDbContext _context;

        public DetailsModel(ScientificArticleSimplifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                Post = post;
            }
            return Page();
        }
    }
}

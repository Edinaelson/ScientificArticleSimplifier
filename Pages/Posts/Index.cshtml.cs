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
    public class IndexModel : PageModel
    {
        private readonly ScientificArticleSimplifier.Data.ApplicationDbContext _context;

        public IndexModel(ScientificArticleSimplifier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Post = await _context.Posts
                .Include(p => p.Request).ToListAsync();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MyItemsModel : PageModel
{
    private readonly AppDbContext _db;
    private const int PageSize = 30;

    public MyItemsModel(AppDbContext db)
    {
        _db = db;
    }

    public List<Item> Items { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int Page { get; set; } = 1;

    public PaginationViewModel Pagination { get; set; } = new();

    public async Task<IActionResult> OnGetAsync()
    {
        var userEmail = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(userEmail))
            return RedirectToPage("/Login");

        var query = _db.Items
                       .Where(i => i.RegistererEmail == userEmail)
                       .OrderByDescending(i => i.CreatedAt);

        var totalItems = await query.CountAsync();
        Pagination.CurrentPage = Page;
        Pagination.TotalPages = (int)System.Math.Ceiling(totalItems / (double)PageSize);
        Pagination.PageName = "/MyItems";

        Items = await query
                  .Skip((Page - 1) * PageSize)
                  .Take(PageSize)
                  .ToListAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var userEmail = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(userEmail))
            return RedirectToPage("/Login");

        var item = await _db.Items.FindAsync(id);
        if (item == null || item.RegistererEmail != userEmail)
            return NotFound();

        _db.Items.Remove(item);
        await _db.SaveChangesAsync();
        return RedirectToPage(new { Page });
    }
}

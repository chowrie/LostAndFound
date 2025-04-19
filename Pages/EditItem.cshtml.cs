using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

public class EditItemModel : PageModel
{
    private readonly AppDbContext _db;

    public EditItemModel(AppDbContext db)
    {
        _db = db;
    }

    [BindProperty]
    public Item Item { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var userEmail = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(userEmail))
        {
            return RedirectToPage("/Login");
        }

        Item = await _db.Items.FindAsync(id);
        if (Item == null || Item.RegistererEmail != userEmail)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var userEmail = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(userEmail))
        {
            return RedirectToPage("/Login");
        }

        var itemToUpdate = await _db.Items.FindAsync(Item.Id);
        if (itemToUpdate == null || itemToUpdate.RegistererEmail != userEmail)
        {
            return NotFound();
        }

        // 仅更新认领人邮箱和是否认领状态
        itemToUpdate.ClaimerEmail = Item.ClaimerEmail;
        itemToUpdate.IsClaimed = Item.IsClaimed;

        await _db.SaveChangesAsync();
        return RedirectToPage("/MyItems");
    }
}

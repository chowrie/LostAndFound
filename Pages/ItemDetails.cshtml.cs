using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ItemDetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public ItemDetailsModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    public Item Item { get; set; }

    public string UserEmail { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        UserEmail = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(UserEmail))
        {
            return RedirectToPage("/Login");
        }

        Item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        if (Item == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostClaimAsync()
    {
        UserEmail = HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(UserEmail))
        {
            return RedirectToPage("/Login");
        }

        Item = await _context.Items.FirstOrDefaultAsync(i => i.Id == Id);
        if (Item == null)
        {
            return NotFound();
        }

        if (Item.RegistererEmail == UserEmail || Item.IsClaimed)
        {
            TempData["Message"] = "您不能认领此物品。";
            return RedirectToPage(new { id = Id });
        }

        var message = new Message
        {
            SenderEmail = UserEmail,
            ReceiverEmail = Item.RegistererEmail,
            ItemId = Item.Id,
            Timestamp = System.DateTime.Now,
            IsRead = false
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        TempData["Message"] = "认领请求已发送给登记人，请等待确认。";
        return RedirectToPage(new { id = Id });
    }
}

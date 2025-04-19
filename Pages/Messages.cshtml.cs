using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LostAndFound.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly AppDbContext _db;
        private const int PageSize = 20;

        public MessagesModel(AppDbContext db)
        {
            _db = db;
        }

        public List<Message> Messages { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int Page { get; set; } = 1;

        public PaginationViewModel Pager { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
                return RedirectToPage("/Login");

            // ����
            var totalCount = await _db.Messages
                .Where(m => m.ReceiverEmail == email)
                .CountAsync();

            // ��ҳ��Ϣ
            Pager.CurrentPage = Page;
            Pager.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            Pager.PageName = "/Messages";

            // ��ȡ��ҳ
            Messages = await _db.Messages
                .Include(m => m.Item)
                .Where(m => m.ReceiverEmail == email)
                .OrderByDescending(m => m.Timestamp)
                .Skip((Page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            // ���δ��Ϊ�Ѷ�
            var unread = await _db.Messages
                .Where(m => m.ReceiverEmail == email && !m.IsRead)
                .ToListAsync();
            if (unread.Any())
            {
                unread.ForEach(m => m.IsRead = true);
                await _db.SaveChangesAsync();
            }

            return Page();
        }
    }
}

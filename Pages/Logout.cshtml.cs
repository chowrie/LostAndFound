using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace LostAndFound.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear(); // ������� Session ����
            return RedirectToPage("/Login"); // �ض��򵽵�¼ҳ��
        }
    }
}

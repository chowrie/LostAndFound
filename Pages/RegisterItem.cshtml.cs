using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

public class RegisterItemModel : PageModel
{
    private readonly AppDbContext _db;
    private readonly IWebHostEnvironment _env;

    public RegisterItemModel(AppDbContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    [BindProperty]
    [Required(ErrorMessage = "此字段为必填项")]
    [Display(Name = "物品名称")]
    public string Name { get; set; }

    [BindProperty]
    [Required(ErrorMessage = "拾取日期不能为空")]
    [Display(Name = "拾取日期")]
    public string PickUpDateInput { get; set; } = DateTime.Now.ToString("yyyy-MM-dd"); // 默认今日

    public DateTime PickUpDate { get; set; }


    [BindProperty]
    [Required(ErrorMessage = "此字段为必填项")]
    [Display(Name = "拾取地点")]
    public string Location { get; set; }

    [BindProperty]
    [Display(Name = "描述")]
    public string? Description { get; set; }

    [BindProperty]
    [Display(Name = "上传图片")]
    public List<IFormFile>? Files { get; set; }

    public IActionResult OnGet()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            return RedirectToPage("/Login");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        ModelState.Remove(nameof(Description));
        ModelState.Remove(nameof(Files));
        ModelState.Remove(nameof(PickUpDate));

        if (!DateTime.TryParse(PickUpDateInput, out var pickUpDateValue))
        {
            ModelState.AddModelError("PickUpDateInput", "日期不合法");
        }
        else
        {
            PickUpDate = pickUpDateValue.Date;
        }
        if (!ModelState.IsValid)
            return Page();

        var userEmail = HttpContext.Session.GetString("Email")!;
        var urls = new List<string>();

        if (Files?.Count > 0)
        {
            var tempDir = Path.Combine(_env.WebRootPath, "temp");
            if (!Directory.Exists(tempDir))
                Directory.CreateDirectory(tempDir);

            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    var ext = Path.GetExtension(file.FileName);
                    var fileName = Guid.NewGuid().ToString("N") + ext;
                    var savePath = Path.Combine(tempDir, fileName);
                    using var fs = new FileStream(savePath, FileMode.Create);
                    await file.CopyToAsync(fs);
                    urls.Add($"/temp/{fileName}");
                }
            }
        }

        var item = new Item
        {
            Name = Name,
            PickUpDate = PickUpDate,
            Location = Location,
            Description = Description,
            ImageUrls = urls.Count > 0 ? string.Join(',', urls) : null,
            IsClaimed = false,
            RegistererEmail = userEmail,
            CreatedAt = DateTime.Now
        };

        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return RedirectToPage("/MyItems");
    }
}

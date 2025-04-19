using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly int _pageSize = 10;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Item> Items { get; set; } = new List<Item>();

    [BindProperty(SupportsGet = true)]
    public string SearchTerm { get; set; }

    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1; 

    public int TotalPages { get; set; }

    public async Task OnGetAsync()
    {
        // 如果表为空则初始化示例数据
        if (!await _context.Items.AnyAsync())
        {
            var items = ItemDataGenerator.GenerateItems();
            _context.Items.AddRange(items);
            await _context.SaveChangesAsync();
        }

        // 1. **排序：按 CreatedAt 降序，最新登记的最前**
        IQueryable<Item> query = _context.Items
                                         .OrderByDescending(i => i.CreatedAt);

        // 2. 搜索过滤
        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            query = query.Where(i =>
                i.Name.Contains(SearchTerm) ||
                (i.Description != null && i.Description.Contains(SearchTerm)) ||
                i.Location.Contains(SearchTerm));
        }

        // 3. 计算总页数
        var totalCount = await query.CountAsync();
        TotalPages = (int)Math.Ceiling(totalCount / (double)_pageSize);

        // 4. 限制 CurrentPage 在合法范围
        if (CurrentPage < 1) CurrentPage = 1;
        if (CurrentPage > TotalPages && TotalPages > 0) CurrentPage = TotalPages;

        // 5. 分页取数据
        Items = await query
            .Skip((CurrentPage - 1) * _pageSize)
            .Take(_pageSize)
            .ToListAsync();

        ViewData["SearchTerm"] = SearchTerm;
    }
}

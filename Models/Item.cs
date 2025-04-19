using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public class Item
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "物品名称不能为空")]
    [Display(Name = "物品名称")]
    public string Name { get; set; }

    [Required(ErrorMessage = "拾取日期不能为空")]
    [DataType(DataType.Date)]
    [Display(Name = "拾取日期")]
    public DateTime PickUpDate { get; set; }

    [Required(ErrorMessage = "拾取地点不能为空")]
    [Display(Name = "拾取地点")]
    public string Location { get; set; }

    [Display(Name = "描述")]
    public string? Description { get; set; }       // 可空

    [Display(Name = "图片网址")]
    public string? ImageUrls { get; set; }         // 可空

    [Display(Name = "是否被认领")]
    public bool IsClaimed { get; set; }

    [Required(ErrorMessage = "登记人邮箱不能为空")]
    [Display(Name = "登记人邮箱")]
    [EmailAddress(ErrorMessage = "邮箱格式不正确")]
    [RegularExpression(@"^.+@mails\.jlu\.edu\.cn$", ErrorMessage = "必须使用@mails.jlu.edu.cn后缀的邮箱")]
    public string RegistererEmail { get; set; }

    [Display(Name = "认领人邮箱")]
    [EmailAddress(ErrorMessage = "邮箱格式不正确")]
    [RegularExpression(@"^.+@mails\.jlu\.edu\.cn$", ErrorMessage = "必须使用@mails.jlu.edu.cn后缀的邮箱")]
    public string? ClaimerEmail { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }


    [NotMapped]
    public List<string> ImageUrlList
    {
        get
        {
            if (string.IsNullOrEmpty(ImageUrls))
                return new List<string>();
            return ImageUrls
                   .Split(',', StringSplitOptions.RemoveEmptyEntries)
                   .Select(url => url.Trim())
                   .ToList();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Message
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "发送人邮箱不能为空")]
    [Display(Name = "发送人邮箱")]
    [EmailAddress(ErrorMessage = "邮箱格式不正确")]
    [RegularExpression(@"^.+@mails\.jlu\.edu\.cn$", ErrorMessage = "必须使用@mails.jlu.edu.cn后缀的邮箱")]
    public string SenderEmail { get; set; }

    [Required(ErrorMessage = "接收人邮箱不能为空")]
    [Display(Name = "接收人邮箱")]
    [EmailAddress(ErrorMessage = "邮箱格式不正确")]
    [RegularExpression(@"^.+@mails\.jlu\.edu\.cn$", ErrorMessage = "必须使用@mails.jlu.edu.cn后缀的邮箱")]
    public string ReceiverEmail { get; set; }

    [ForeignKey("Item")]
    [Display(Name = "物品ID")]
    public int ItemId { get; set; }

    public Item Item { get; set; } // 导航属性
    public DateTime Timestamp { get; set; } = DateTime.Now; // 添加时间戳
    public bool IsRead { get; set; } = false; // 添加已读状态
}

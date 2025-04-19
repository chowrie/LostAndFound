using System;
using System.Collections.Generic;

public static class ItemDataGenerator
{
    public static List<Item> GenerateItems()
    {
        var items = new List<Item>();
        Random random = new Random();

        // 1
        items.Add(new Item
        {
            Id = 1,
            Name = "黑色钱包",
            PickUpDate = DateTime.Now.AddDays(-1),
            CreatedAt = DateTime.Now.AddDays(-1).AddHours(random.Next(1, 6)),
            Location = "中心图书馆一楼",
            Description = "内有身份证和少量现金。",
            ImageUrls = "https://example.com/wallet1.jpg,https://example.com/wallet2.jpg",
            IsClaimed = false,
            RegistererEmail = "user1@mails.jlu.edu.cn"
        });
        // 2
        items.Add(new Item
        {
            Id = 2,
            Name = "蓝色水杯",
            PickUpDate = DateTime.Now.AddDays(-3),
            CreatedAt = DateTime.Now.AddDays(-3).AddHours(random.Next(1, 6)),
            Location = "教学楼A区201",
            Description = "印有卡通图案。",
            ImageUrls = "https://example.com/cup1.jpg",
            IsClaimed = false,
            RegistererEmail = "user2@mails.jlu.edu.cn"
        });
        // 3
        items.Add(new Item
        {
            Id = 3,
            Name = "学生证",
            PickUpDate = DateTime.Now.AddDays(-7),
            CreatedAt = DateTime.Now.AddDays(-7).AddHours(random.Next(1, 6)),
            Location = "体育馆门口",
            Description = "李明，信息工程学院。",
            ImageUrls = "https://example.com/idcard1.jpg",
            IsClaimed = false,
            RegistererEmail = "user3@mails.jlu.edu.cn"
        });
        // 4
        items.Add(new Item
        {
            Id = 4,
            Name = "小米耳机",
            PickUpDate = DateTime.Now.AddDays(-2),
            CreatedAt = DateTime.Now.AddDays(-2).AddHours(random.Next(1, 6)),
            Location = "食堂二楼",
            Description = "无线蓝牙耳机，白色。",
            ImageUrls = "https://example.com/earphone1.jpg",
            IsClaimed = false,
            RegistererEmail = "user4@mails.jlu.edu.cn"
        });
        // 5
        items.Add(new Item
        {
            Id = 5,
            Name = "雨伞",
            PickUpDate = DateTime.Now.AddDays(-5),
            CreatedAt = DateTime.Now.AddDays(-5).AddHours(random.Next(1, 6)),
            Location = "宿舍楼下",
            Description = "黑色长柄伞。",
            ImageUrls = "https://example.com/umbrella1.jpg",
            IsClaimed = false,
            RegistererEmail = "user5@mails.jlu.edu.cn"
        });
        // 6
        items.Add(new Item
        {
            Id = 6,
            Name = "机械键盘",
            PickUpDate = DateTime.Now.AddDays(-4),
            CreatedAt = DateTime.Now.AddDays(-4).AddHours(random.Next(1, 6)),
            Location = "计算机实验室",
            Description = "青轴键盘，有磨损。",
            ImageUrls = "https://example.com/keyboard1.jpg",
            IsClaimed = false,
            RegistererEmail = "user6@mails.jlu.edu.cn"
        });
        // 7
        items.Add(new Item
        {
            Id = 7,
            Name = "红色帽子",
            PickUpDate = DateTime.Now.AddDays(-6),
            CreatedAt = DateTime.Now.AddDays(-6).AddHours(random.Next(1, 6)),
            Location = "操场看台",
            Description = "针织帽，带有白色条纹。",
            ImageUrls = "https://example.com/hat1.jpg",
            IsClaimed = false,
            RegistererEmail = "user7@mails.jlu.edu.cn"
        });
        // 8
        items.Add(new Item
        {
            Id = 8,
            Name = "考研资料",
            PickUpDate = DateTime.Now.AddDays(-8),
            CreatedAt = DateTime.Now.AddDays(-8).AddHours(random.Next(1, 6)),
            Location = "自习室",
            Description = "高等数学和英语资料。",
            ImageUrls = "https://example.com/study_material1.jpg",
            IsClaimed = false,
            RegistererEmail = "user8@mails.jlu.edu.cn"
        });
        // 9
        items.Add(new Item
        {
            Id = 9,
            Name = "饭卡",
            PickUpDate = DateTime.Now.AddDays(-9),
            CreatedAt = DateTime.Now.AddDays(-9).AddHours(random.Next(1, 6)),
            Location = "小卖部",
            Description = "卡号：123456789。",
            ImageUrls = "https://example.com/mealcard1.jpg",
            IsClaimed = false,
            RegistererEmail = "user9@mails.jlu.edu.cn"
        });
        // 10
        items.Add(new Item
        {
            Id = 10,
            Name = "U盘",
            PickUpDate = DateTime.Now.AddDays(-10),
            CreatedAt = DateTime.Now.AddDays(-10).AddHours(random.Next(1, 6)),
            Location = "多媒体教室",
            Description = "32G，黑色。",
            ImageUrls = "https://example.com/usb1.jpg",
            IsClaimed = false,
            RegistererEmail = "user10@mails.jlu.edu.cn"
        });
        // 11
        items.Add(new Item
        {
            Id = 11,
            Name = "眼镜",
            PickUpDate = DateTime.Now.AddDays(-11),
            CreatedAt = DateTime.Now.AddDays(-11).AddHours(random.Next(1, 6)),
            Location = "医务室",
            Description = "近视镜，黑色镜框。",
            ImageUrls = "https://example.com/glasses1.jpg",
            IsClaimed = false,
            RegistererEmail = "user11@mails.jlu.edu.cn"
        });
        // 12
        items.Add(new Item
        {
            Id = 12,
            Name = "笔记本",
            PickUpDate = DateTime.Now.AddDays(-12),
            CreatedAt = DateTime.Now.AddDays(-12).AddHours(random.Next(1, 6)),
            Location = "图书馆",
            Description = "记录了课程笔记。",
            ImageUrls = "https://example.com/notebook1.jpg",
            IsClaimed = false,
            RegistererEmail = "user12@mails.jlu.edu.cn"
        });
        // 13
        items.Add(new Item
        {
            Id = 13,
            Name = "手套",
            PickUpDate = DateTime.Now.AddDays(-13),
            CreatedAt = DateTime.Now.AddDays(-13).AddHours(random.Next(1, 6)),
            Location = "校门口",
            Description = "棉手套，蓝色。",
            ImageUrls = "https://example.com/gloves1.jpg",
            IsClaimed = false,
            RegistererEmail = "user13@mails.jlu.edu.cn"
        });
        // 14
        items.Add(new Item
        {
            Id = 14,
            Name = "钥匙",
            PickUpDate = DateTime.Now.AddDays(-14),
            CreatedAt = DateTime.Now.AddDays(-14).AddHours(random.Next(1, 6)),
            Location = "快递点",
            Description = "包含宿舍钥匙和储物柜钥匙。",
            ImageUrls = "https://example.com/keys1.jpg",
            IsClaimed = false,
            RegistererEmail = "user14@mails.jlu.edu.cn"
        });
        // 15
        items.Add(new Item
        {
            Id = 15,
            Name = "护照",
            PickUpDate = DateTime.Now.AddDays(-15),
            CreatedAt = DateTime.Now.AddDays(-15).AddHours(random.Next(1, 6)),
            Location = "国际交流中心",
            Description = "请尽快联系失主。",
            ImageUrls = "https://example.com/passport1.jpg",
            IsClaimed = false,
            RegistererEmail = "user15@mails.jlu.edu.cn"
        });
        // 16
        items.Add(new Item
        {
            Id = 16,
            Name = "书包",
            PickUpDate = DateTime.Now.AddDays(-16),
            CreatedAt = DateTime.Now.AddDays(-16).AddHours(random.Next(1, 6)),
            Location = "教学楼C区门口",
            Description = "黑色双肩包，装有课本和作业。",
            ImageUrls = "https://example.com/backpack1.jpg",
            IsClaimed = false,
            RegistererEmail = "user16@mails.jlu.edu.cn"
        });
        // 17
        items.Add(new Item
        {
            Id = 17,
            Name = "保温杯",
            PickUpDate = DateTime.Now.AddDays(-17),
            CreatedAt = DateTime.Now.AddDays(-17).AddHours(random.Next(1, 6)),
            Location = "体育馆健身区",
            Description = "不锈钢材质，有轻微划痕。",
            ImageUrls = "https://example.com/thermos1.jpg",
            IsClaimed = false,
            RegistererEmail = "user17@mails.jlu.edu.cn"
        });
        // 18
        items.Add(new Item
        {
            Id = 18,
            Name = "移动硬盘",
            PickUpDate = DateTime.Now.AddDays(-18),
            CreatedAt = DateTime.Now.AddDays(-18).AddHours(random.Next(1, 6)),
            Location = "图书馆阅览室",
            Description = "1TB，存储了大量学习资料。",
            ImageUrls = "https://example.com/external_hard_drive1.jpg",
            IsClaimed = false,
            RegistererEmail = "user18@mails.jlu.edu.cn"
        });
        // 19
        items.Add(new Item
        {
            Id = 19,
            Name = "平板电脑",
            PickUpDate = DateTime.Now.AddDays(-19),
            CreatedAt = DateTime.Now.AddDays(-19).AddHours(random.Next(1, 6)),
            Location = "咖啡厅",
            Description = "iPad，银色，已设置密码。",
            ImageUrls = "https://example.com/tablet1.jpg",
            IsClaimed = false,
            RegistererEmail = "user19@mails.jlu.edu.cn"
        });
        // 20
        items.Add(new Item
        {
            Id = 20,
            Name = "围巾",
            PickUpDate = DateTime.Now.AddDays(-20),
            CreatedAt = DateTime.Now.AddDays(-20).AddHours(random.Next(1, 6)),
            Location = "艺术楼",
            Description = "羊毛围巾，灰色。",
            ImageUrls = "https://example.com/scarf1.jpg",
            IsClaimed = false,
            RegistererEmail = "user20@mails.jlu.edu.cn"
        });
        // 21
        items.Add(new Item
        {
            Id = 21,
            Name = "校徽",
            PickUpDate = DateTime.Now.AddDays(-21),
            CreatedAt = DateTime.Now.AddDays(-21).AddHours(random.Next(1, 6)),
            Location = "校史馆",
            Description = "金属材质，背面刻有校训。",
            ImageUrls = "https://example.com/school_badge1.jpg",
            IsClaimed = false,
            RegistererEmail = "user21@mails.jlu.edu.cn"
        });

        return items;
    }
}

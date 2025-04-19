# 失物招领系统

## 项目简介

本系统是一个基于 ASP.NET Core 的简单失物招领系统，方便用户发布、浏览和认领失物。

## 功能特性

- 失物信息发布、展示与搜索
- 失物详情页面
- 认领状态标记（已认领/未认领）
- 通过邮箱发送验证码（使用QQ邮箱SMTP服务）

## 技术栈

- ASP.NET Core Razor Pages
- C#
- Entity Framework Core
- SQLite
- SMTP 邮件服务

## 环境要求

- .NET 9.0 SDK

## 使用说明
- **配置邮箱：**  
  本项目使用QQ邮箱的SMTP服务，需在`appsettings.json`中配置自己的邮箱和SMTP授权码。示例配置：  
  ```json
  "SmtpSettings": {
    "Host": "smtp.qq.com",
    "Port": 587,
    "EnableSsl": true,
    "UserName": "your_email@qq.com",
    "Password": "your_smtp_authorization_code"
  }


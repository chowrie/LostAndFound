using System.Net.Mail;
using System.Net;
using System;

public class EmailService
{
    private readonly string _smtpServer;
    private readonly int _smtpPort;
    private readonly string _smtpUsername;
    private readonly string _smtpPassword;

    public EmailService(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
    {
        _smtpServer = smtpServer;
        _smtpPort = smtpPort;
        _smtpUsername = smtpUsername;
        _smtpPassword = smtpPassword;
    }

    public bool SendVerificationCode(string toEmail, string verificationCode)
    {
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_smtpUsername);
            message.To.Add(toEmail);
            message.Subject = "失物招领系统邮箱验证码";
            message.Body = $"您的验证码是: {verificationCode}，有效期为5分钟。";
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient(_smtpServer, _smtpPort);
            smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
            return true;
        }
        catch (Exception ex)
        {
            // 记录错误日志
            Console.WriteLine($"发送邮件失败: {ex.Message}");
            return false;
        }
    }
}

﻿namespace Project3_nhom4.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
    }
}

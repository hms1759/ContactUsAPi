﻿namespace StartClassTest.ConfigModel
{
    public class EmailConfigSettings
    {
        public string? DisplayName { get; set; }
        public string? From { get; set; }
        public string[] MailTo { get; set; } = Array.Empty<string>();
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ContactTopic { get; set; }
        public string? RequestTopic { get; set; }
        public string? NotificationTopic { get; set; }
    }
}

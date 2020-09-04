using EmailService.Common.Interfaces;

namespace EmailService.Common.DataClasses
{
    public class SMTPData : ISMTPData
    {
        public string SMTPAccount { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
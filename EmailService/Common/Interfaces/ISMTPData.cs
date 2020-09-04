namespace EmailService.Common.Interfaces
{
    public interface ISMTPData
    {
        string SMTPAccount { get; set; }
        string Name { get; set; }
        string Password { get; set; }
    }
}
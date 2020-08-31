namespace EmailService.Database.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }
}
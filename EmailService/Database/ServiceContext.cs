using EmailService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailService.Database
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options)
        {
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
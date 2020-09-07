using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Autofac.Extras.Moq;
using EmailService.Common.Interfaces;
using EmailService.Database.Entities;
using EmailService.Database.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetAllEmailsUnitTest
{
    [TestClass]
    public class GetAllEmailsUnitTests
    {

        [TestMethod]
        public void GetAllEmailsUnitTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //mock.Mock<IEmailRepository>().Setup(x=>x.GetAllEmails(new  CancellationToken()).Result).Returns(GetSampleEmails());
                mock.Mock<IEmailRepository>().Setup(x => x.CreateEmail(new Email()
                {
                    Id = 1,
                    Sender = new EmailAddress() { Id = 1, Name = "John", Value = "john@john.com" },
                    Send = false,
                    Text = "test text",
                    Priority = Priority.Spam,
                    Subject = "Subject"
                }, new CancellationToken()));
                Assert.AreEqual(mock.Mock<IEmailRepository>().Object.GetAllEmails(new CancellationToken()).Result.Count(), 0);
            }
        }

        private List<Email> GetSampleEmails()
        {
            List<Email> output = new List<Email>()
            {
                new Email()
                {
                    Id = 1,
                    Sender = new EmailAddress() {Id = 1, Name = "John", Value = "john@john.com"},
                    Send = false,
                    Text = "test text",
                    Priority = Priority.Spam,
                    Subject = "Subject"
                },
                new Email()
                {
                    Id = 2,
                    Sender = new EmailAddress() {Id = 1, Name = "John", Value = "john@john.com"},
                    Send = false,
                    Text = "test text 2",
                    Priority = Priority.Normal,
                    Subject = "Subject 2"
                },
                new Email
                {
                    Id = 3,
                    Sender = new EmailAddress() {Id = 1, Name = "Anna", Value = "anna@anna.com"},
                    Send = false,
                    Text = "test text 3",
                    Priority = Priority.Important,
                    Subject = "Subject 3"
                },
            };
            return output;
        }

    }
}

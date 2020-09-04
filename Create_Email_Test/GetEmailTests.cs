using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EmailService.Common.DataClasses;
using EmailService.Common.Interfaces;
using EmailService.Controllers;
using EmailService.Database.Entities;
using EmailService.Database.Enums;
using EmailService.Database.Queries.Emails;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Create_Email_Test
{
    [TestClass]
    public class GetEmailTests
    {

        private Mock<IMediator> _mediator;

        private IEmailRepository _sut;

        [TestInitialize]
        public void Setup()
        {

            _mediator = new Mock<IMediator>(MockBehavior.Strict);

            _sut = new Mock<IEmailRepository>().Object;
        }

        [TestCleanup]
        public void Teardown()
        {

            _mediator.VerifyAll();
        }

        [TestMethod]
        public void GetEmailTest()
        {/*
            var email = new Email() {Id=0,Text = "Test message", Subject = "test subject",
                    Priority = Priority.Important, Send = false, Sender = new EmailAddress()
                        {Id=0,Name ="Marcin", Value = @"marcin.czlonka@onet.com.pl"}, Recipients = 
                        new List<EmailAddress>(){ new EmailAddress(){Id=0,Name ="Marcin", Value = @"marcin.czlonka@onet.com.pl"}}
            };

            _mediator.Setup(x => x.Send(It.IsAny<GetEmailDetailsQuery>(), default(CancellationToken))).ReturnsAsync(email).Callback(
                (GetAllEmailsQuery message, CancellationToken token) =>
                {
                    Assert.IsNotNull(message);
                });

            Assert.AreEqual(_sut.GetEmail(0,new CancellationToken()), email);*/
        }

    }
}

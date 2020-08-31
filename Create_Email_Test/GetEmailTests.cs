using System.Collections.Generic;
using System.Threading;
using EmailService.Common.DataClasses;
using EmailService.Controllers;
using EmailService.Database.Entities;
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

        private BaseController _sut;

        [TestInitialize]
        public void Setup()
        {

            _mediator = new Mock<IMediator>(MockBehavior.Strict);

            _sut = new EmailController();
        }

        [TestCleanup]
        public void Teardown()
        {

            _mediator.VerifyAll();
        }

        [TestMethod]
        public void GetEmailTest()
        {
            var dbObjects = new List<Email>() {
                new Email(),
                new Email()
            };
            /*
            _mediator.Setup(x => x.Send(It.IsAny<GetAllEmailsQuery>(), default(CancellationToken))
                .ReturnsAsync(dbObjects.ToArray()).Callback(
                (GetAllEmailsQuery message, CancellationToken token) => 
                {
                    Assert.IsNotNull(message);
                });*/

        }

    }
}

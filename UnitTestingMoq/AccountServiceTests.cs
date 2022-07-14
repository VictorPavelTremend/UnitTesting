using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using UnitTesting;
using Xunit;

namespace UnitTestingMoq
{
    [TestClass]
    public class AccountServiceTests
    {
        [Fact]
        public void GetAllBooksForCategory_returns_list_of_available_books()
        {
            //1
            var bookServiceStub = new Mock<IBookService>();

            //2
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
            "The Art of Unit Testing",
            "Test-Driven Development",
            "Working Effectively with Legacy Code"
                });

            //3
            var accountService = new AccountService(bookServiceStub.Object, null);

            IEnumerable<string> result = accountService.GetAllBooksForCategory("UnitTesting");

            Xunit.Assert.Equal(3, result.Count());
        }
    }
}
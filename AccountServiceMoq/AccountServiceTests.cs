using AccountServiceNS;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AccountServiceMoq
{
    public class AccountServiceTests
    {
        [Fact]
        // UnitOfWork_ScenarioUnderTest_ExpectedBehavior
        public void GetAllBooksForCategory_ReturnAllBooks_ReturnTrue()
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

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetISBNFor_LookForSecificBook_ReturnFoundBook()
        {
            var bookServiceStub = new Mock<IBookService>();

            //1
            bookServiceStub
                .Setup(x => x.GetBooksForCategory("UnitTesting"))
                .Returns(new List<string>
                {
            "The Art of Unit Testing",
            "Test-Driven Development",
            "Working Effectively with Legacy Code"
                });
            //2
            bookServiceStub
                .Setup(x => x.GetISBNFor("The Art of Unit Testing"))
                .Returns("0-9020-7656-6");

            var accountService = new AccountService(bookServiceStub.Object, null);

            string result = accountService.GetBookISBN("UnitTesting", "art");

            Assert.Equal("0-9020-7656-6", result);
        }
    }
}
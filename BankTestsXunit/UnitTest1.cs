using BankAccountNS;
using Xunit;

namespace BankTestsXunit
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(11.99, 4.55, 7.44)]
        [InlineData(11.99, 4.55, -7.44)]
        [InlineData(11.99, 4.55, 17.44)]
        // TestMethod naming convention
        // UnitOfWork_ExpectedBehavior_ScenarioUnderTest
        public void Debit_WithValidAmount_UpdatesBalance(double beginningBalance, double debitAmount, double expected = 7.44)
        {
            // Arrange            
            BankAccount account = new BankAccount("Vasile Alecsandri", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Xunit.Assert.Equal(expected, actual);
        }
    }
}
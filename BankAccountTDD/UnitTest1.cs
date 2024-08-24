namespace BankAccountTDD
{
    public class UnitTest1
    {
        BankAccount _account;
        public UnitTest1()
        {
            _account = new BankAccount();
        }

        [Theory]
        [InlineData(100)]
        [InlineData(50)]
        public void DoesDepositValidAmountIncreasesBalance(double amount)
        {
            double initialBalance = _account.GetBalance();

            _account.Deposit(amount);

            Assert.Equal(initialBalance + amount, _account.GetBalance());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-50)]
        public void DepositInvalidAmountThrowsArgumentException(double amount)
        {

            Assert.Throws<ArgumentException>(() => _account.Deposit(amount));
        }

        [Theory]
        [InlineData(50)]
        public void WithdrawValidAmountDecreasesBalance(double amount)
        {

            double initialBalance = _account.GetBalance();


            _account.Withdraw(amount);


            Assert.Equal(initialBalance - amount, _account.GetBalance());
        }

        [Theory]
        [InlineData(150)]
        public void WithdrawAmountGreaterThanBalanceThrowsInvalidOperationException(double amount)
        {

            double initialBalance = _account.GetBalance();

            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(amount));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-50)]
        public void WithdrawInvalidAmountThrowsArgumentException(double amount)
        {
            Assert.Throws<ArgumentException>(() => _account.Withdraw(amount));
        }



        [Theory]
        [InlineData(50)]
        public void TransferValidAccountWithdrawsFromSourceAndDepositsToTarget(double amount)
        {
            var toAccount = new BankAccount();
            double myBalance = _account.GetBalance();
            double otherParty = toAccount.GetBalance();

            _account.Transfer(toAccount, amount);

            Assert.Equal(myBalance - amount, _account.GetBalance());
            Assert.Equal(otherParty + amount, toAccount.GetBalance());
        }


        [Theory]
        [InlineData(50)]
        public void TransferInvalidAccountThrowsArgumentNullException(double amount)
        {

            Assert.Throws<ArgumentNullException>(() => _account.Transfer(null, amount));
        }

    }
}
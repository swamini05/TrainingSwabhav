namespace BankAccountTDD
{
    internal class BankAccount
    {
        private double _balance = 100;
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be Positive");
            }

            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("withdrawal amount must be positive");
            }

            if (amount > _balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            _balance -= amount;
        }
        public double GetBalance()
        {
            return _balance;
        }

        public void Transfer(BankAccount toAccount, double amount)
        {
            if (toAccount == null)
            {
                throw new ArgumentNullException(nameof(toAccount));
            }
            Withdraw(amount);
            toAccount.Deposit(amount);
        }

    }
}

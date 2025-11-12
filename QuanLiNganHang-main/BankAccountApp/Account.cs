using System;

namespace BankAccountApp
{
    public class Account
    {
        public string Number { get; set; }
        public string Owner { get; set; }
        public double Balance { get; private set; }
        public DateTime OpenedAt { get; private set; }
        public static double InterestRate { get; set; } = 0.02;
        public string Note { get; set; } = "";
        public Account()
        {
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Owner = "Unknown";
            Balance = 0;
            OpenedAt = DateTime.Now;
        }

        public Account(string number, string owner, double balance)
        {
            Number = number;
            Owner = owner;
            Balance = balance;
            OpenedAt = DateTime.Now;
        }

 

        public Account(Account other)
        {
            Number = other.Number;
            Owner = other.Owner;
            Balance = other.Balance;
            OpenedAt = other.OpenedAt;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Invalid deposit amount");
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0 || amount > Balance) throw new ArgumentException("Invalid withdraw amount");
            Balance -= amount;
        }

        public void Transfer(Account to, double amount)
        {
            Withdraw(amount);
            to.Deposit(amount);
        }

        public void Transfer(Bank bank, string toNumber, double amount)
        {
            Account to = bank[toNumber];
            if (to == null) throw new Exception("Target account not found");
            Transfer(to, amount);
        }

        public void ApplyMonthlyInterest()
        {
            Balance += Balance * InterestRate / 12;
        }
    }
}

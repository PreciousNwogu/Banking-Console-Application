using System;

public class Account
{
    private static readonly Random random = new Random();
    public int AccountNumber { get; private set; }
    public string OwnerName { get; set; }
    public double Balance { get; private set; }
    public const double MinimumInitialBalance = 100;

    public Account(string ownerName, double initialBalance)
    {
        AccountNumber = random.Next(100000, 999999);
        OwnerName = ownerName;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        Balance -= amount;
    }
}
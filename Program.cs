using System;
using System.Collections.Generic;

class Program
{
    static List<Account> accounts = new List<Account>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to online banking app. \nKindly choose an option to proceed.");

            Console.WriteLine("\n 1. View Accounts\n 2. Create Account\n 3. Deposit\n 4. Withdraw\n 5. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewAccounts();
                    break;
                case "2":
                    CreateAccount();
                    break;
                case "3":
                    Deposit();
                    break;
                case "4":
                    Withdraw();
                    break;
                case "5":
                    Console.WriteLine(" Thanks for banking with us");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void ViewAccounts()
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("No accounts found");
        }
        else
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountNumber: {account.AccountNumber}, \nOwnerName: {account.OwnerName}, \nBalance: {account.Balance}");
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter the account owner's name: ");
        string ownerName = Console.ReadLine();
        if (string.IsNullOrEmpty(ownerName))
        {
            Console.WriteLine("Owner name cannot be empty.");
            return;
        }

        double initialBalance;
        while (true)
        {
            Console.Write("Enter the initial account balance: ");
            if (double.TryParse(Console.ReadLine(), out initialBalance))
            {
                if (initialBalance >= Account.MinimumInitialBalance)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Your minimum initial balance is: {Account.MinimumInitialBalance}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid balance amount. Please enter a valid number.");
            }
        }

        var account = new Account(ownerName, initialBalance);
        accounts.Add(account);
        Console.WriteLine($"Account is successfully created:\nAccountNumber:{account.AccountNumber}, \nOwnerName: {account.OwnerName}, \nBalance: {account.Balance}");
    }

    static void Deposit()
    {
        Console.Write("Enter the AccountNumber: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter the deposit amount: ");
            if (double.TryParse(Console.ReadLine(), out double depositAmount) && depositAmount > 0)
            {
                account.Deposit(depositAmount);
                Console.WriteLine($"Deposit Suucessful. \nNew balance for AccountNumber {account.AccountNumber}: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid AccountNumber.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter the AccountNumber: ");
        if (int.TryParse(Console.ReadLine(), out int accountNumber))
        {
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.Write("Enter the withdrawal amount: ");
            if (double.TryParse(Console.ReadLine(), out double withdrawalAmount) && withdrawalAmount > 0)
            {
                if (withdrawalAmount <= account.Balance)
                {
                    account.Withdraw(withdrawalAmount);
                    Console.WriteLine($"Withdrawal Suucessful.\nNew balance for AccountNumber {account.AccountNumber}: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid AccountNumber.");
        }
    }
}
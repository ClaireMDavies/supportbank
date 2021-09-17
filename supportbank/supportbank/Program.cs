using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supportbank
{
    class Program
    {
        static Dictionary<string, Account> _accounts = new Dictionary<string, Account>();

        //

        //function to create a list of all accounts and whether money is owed or not
        public static void ListAll()
        {
            foreach (var keyValuePair in  _accounts)
                {
                var account = keyValuePair.Value;
                if (account.Balance > 0)
                {
                    Console.WriteLine($"{account.Name} is owed £{account.Balance}");
                }
                else
                {
                    Console.WriteLine($"{account.Name} owes £{-account.Balance}");
                }
            }
        }

        public static void ListAccount(string accountName)
        {
           
            if (_accounts.ContainsKey(accountName))
            {
                var currentAccount = _accounts[accountName];
                var transactions = currentAccount.Transactions;

                Console.WriteLine($"Account Name: {currentAccount.Name}");
                foreach (var transaction in transactions)
                {
                  
                    Console.WriteLine($"{transaction.Date}: {transaction.FromName} paid {transaction.ToName} {transaction.Amount} for {transaction.Narrative}");

                }
                    
            }
            else
            {
                Console.WriteLine("no account of this name exists");
            }
        }

        public static void CommandLineInput()
        {
            Console.WriteLine("Write 'List All' for all accounts, or the name of the account to view");
            string command = Console.ReadLine();


            if (command == "List All")
            {
                ListAll();
                Console.ReadLine();
            }
            else
            {
                ListAccount(command);
                Console.ReadLine();
            }

        }

        static void Main(string[] args)
        {
            

            // read lines from the file
            string path = "C:\\apprenticeship\\supportBank\\supportbank\\supportbank\\Transactions2014.csv"; 
            
            // create a list / array / dictionary of Transactions
            string[] transactionRecords = File.ReadAllLines(path);


            // for each line in transactionsRecords
            foreach (string record in transactionRecords.Skip(1))
            {
                
                    string[] transactionFields = record.Split(',');

                    string date = transactionFields[0];
                    string fromName = transactionFields[1];
                    string toName = transactionFields[2];
                    string why = transactionFields[3];
                    float amount = float.Parse(transactionFields[4]);



                
                //writing info from csv file to account
                Account fromAccount = GetAccountByName(fromName);
                fromAccount.WithdrawFunds(date, fromName, toName, amount, why);

                Account toAccount = GetAccountByName(toName);
                toAccount.AddFunds(date, fromName, toName, amount, why);


            }


            //create a command line input  
            CommandLineInput();
           
            

        }
        
        //Checking if account name exists, and if it doesn't creating account in dictionary
        private static Account GetAccountByName(string accountName)
        {
            if (_accounts.ContainsKey(accountName))
            {
                return _accounts[accountName];
            }
            else
            {
                Account newAccount = new Account();
                newAccount.Name = accountName;
                _accounts.Add(accountName, newAccount);
                return newAccount;

                
            }
        }


    }
}

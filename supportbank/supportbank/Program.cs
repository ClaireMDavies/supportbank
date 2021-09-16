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
                    Console.WriteLine(($"{account.Name} owes £{-account.Balance}"));
                }
            }
        }
        static void Main(string[] args)
        {
            

            // read lines from the file
            string path = "C:\\apprenticeship\\supportBank\\supportbank\\supportbank\\Transactions2014.csv"; 
            
            // create a list / array / dictionary of Transactions
            string[] transactionRecords = File.ReadAllLines(path);


            // for each line in transactionsData
            foreach (string record in transactionRecords.Skip(1))
            {
                
                    string[] transactionFields = record.Split(',');

                    string date = transactionFields[0];
                    string fromName = transactionFields[1];
                    string toName = transactionFields[2];
                    string why = transactionFields[3];
                    float amount = float.Parse(transactionFields[4]);



                //Console.WriteLine($"date: {date}  from:{fromName} to:{toName} narrative:{why}  amount:{amount}");

                Account fromAccount = GetAccountByName(fromName);
                fromAccount.WithdrawFunds(date, toName, amount, why);

                Account toAccount = GetAccountByName(toName);
                toAccount.AddFunds(date, fromName, amount, why);


            }


            //call listall method
            ListAll();
            Console.ReadLine();

        }
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

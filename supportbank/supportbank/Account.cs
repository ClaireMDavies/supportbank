using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supportbank
{
    class Account
    {
        public List<Transaction> Transactions = new List<Transaction>();

        public string Name { get; set; }
        public float Balance { get; private set; }

        public void AddFunds(string date, string fromName, float amount, string why)
        {
            Balance += amount;

            Transaction transaction = new Transaction();
            transaction.Date = date;
            transaction.FromName = fromName;
            transaction.Amount = amount;
            transaction.Narrative = why;
            Transactions.Add(transaction);
        }

        public void WithdrawFunds(string date, string toName, float amount, string why)
        {
            Balance -= amount;

            Transaction transaction = new Transaction();
            transaction.Date = date;
            transaction.ToName = toName;
            transaction.Amount = amount;
            transaction.Narrative = why; 
            Transactions.Add(transaction);
        }

        
    }
}

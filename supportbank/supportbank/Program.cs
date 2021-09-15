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
        static void Main(string[] args)
        {
            // read lines from the file
            string path = "C:\\apprenticeship\\supportBank\\supportbank\\supportbank\\Transactions2014.csv";
            string[] transactionData = File.ReadAllLines(path);

            

            foreach ( string line in transactionData)
            {
                
                string date = line.Split(',')[0];
                string from = line.Split(',')[1];
                string to = line.Split(',')[2];
                string narrative = line.Split(',')[3];
                string amount = line.Split(',')[4];

                Console.WriteLine($"date: {date}  from:{from} to:{to} narrative:{narrative}  amount:{amount}");
            

            }
            Console.ReadLine();

            
            // create a list / array / dictionary of Transactions

            // for each line in linesArray
                // create a Transaction object
                // split up the line to find the date, amount, etc.
                // store those values in the object
                // add the object to our list / array / etc

            // for each transaction in the list / array / etc
                // write the transaction to the console


        }
    }
}

using System.Linq;
using System;
using System.Collections.Generic;

namespace linq
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }



    public class Programs
    {
        public static void Customers()
        {
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.69, Bank="CITI"}
        };


            IEnumerable<Customer> millionaires = customers.Where(number => number.Balance >= 1000000);
            foreach (var person in millionaires)
            {
                Console.WriteLine(person.Name);

            }


            List<BankReport> bankReports = (from customer in millionaires
                                            group customer by customer.Bank into bankGroup
                                            select new BankReport
                                            {
                                                BankName = bankGroup.Key,
                                                CustomerCount = bankGroup.Count()
                                            }

             ).ToList();

            Console.WriteLine("BANK REPORT!!!!!!!!!!!!");
            bankReports.ForEach(report => Console.WriteLine($"{report.BankName}: {report.CustomerCount}"));


        }
        public class BankReport
        {
            public string BankName { get; set; }
            public int CustomerCount { get; set; }
        }
    }
}



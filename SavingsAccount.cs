using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class SavingsAccount:UniversalAccount
    {
        protected double interest_rate;         //annual interest rate 
        protected DateTime paymentDate;         //date of last percents' payment

        public SavingsAccount(int number, string password, double balance, double rate, DateTime openDate)
        {
            this.number = number;
            this.password = password;
            this.balance = balance;
            this.interest_rate = rate;
            this.openDate = openDate;
            this.paymentDate = openDate;
        }

        public SavingsAccount()
        { }

        public override double CheckBalance(DateTime currentDate)
        {
            double currentBalance = this.balance;
            int months = CountMonths(currentDate, paymentDate);

            for (int i = 0; i < months; i++)
                currentBalance *= (1 + interest_rate / 100 / 12);

            return currentBalance;
        }

        public override void PutMoney(double sum, DateTime currentDate)
        {
            balance = CheckBalance(currentDate);
            paymentDate = new DateTime(currentDate.Year, currentDate.Month, openDate.Day);
            balance += sum;
        }

        public override double WithdrawMoney(double sum, DateTime currentDate)
        {
            this.balance = CheckBalance(currentDate);
            paymentDate = new DateTime(currentDate.Year, currentDate.Month, openDate.Day);

            if (balance >= sum)
            {
                balance -= sum;
                return sum;
            }
            else
            {
                Console.WriteLine("Not enough money");
                return 0;
            }
        }
    }
}

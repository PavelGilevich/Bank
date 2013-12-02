using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class TimedMaturityAccount:SavingsAccount
    {
        double penalty_rate;
        int period;

        public TimedMaturityAccount(int number, string password, double balance, double rate, DateTime openDate, double penalty_rate, int period)
        {
            this.number = number;
            this.password = password;
            this.balance = balance;
            this.interest_rate = rate;
            this.openDate = openDate;
            this.paymentDate = openDate;
            this.penalty_rate = penalty_rate;
            this.period = period;
        }

        public override void PutMoney(double sum, DateTime currentDate)
        {
            balance = CheckBalance(currentDate);
            paymentDate = new DateTime(currentDate.Year, currentDate.Month, openDate.Day);
            balance += sum;
        }

        public override double CheckBalance(DateTime currentDate)
        {
            double currentBalance = this.balance;
            int months = CountMonths(currentDate, paymentDate);

            for (int i = 0; i < months; i++)
                currentBalance *= (1 + interest_rate / 100 / 12);

            return currentBalance;
        }

        public override double WithdrawMoney(double sum, DateTime currentDate)
        {
            this.balance = CheckBalance(currentDate);
            if (sum > balance)
            {
                Console.WriteLine("Not enough money");
                return 0;
            }
            else
            {
                balance -= sum;
                int months = CountMonths(currentDate, openDate);

                if (months < period)
                {
                    return (sum * (100 - penalty_rate)/100);
                }
                else
                    return sum;
            }
        }
    }
}

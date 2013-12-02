using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class OverdraftAccount:UniversalAccount
    {
        double interest_rate;
        double start_balance;
        DateTime penalty_start_date;

        public OverdraftAccount(int number, string password, double balance, DateTime openDate, double int_rate)
        {
            this.number = number;
            this.password = password;
            this.start_balance = balance;
            this.balance = balance;
            this.openDate = openDate;
            this.interest_rate = int_rate;
        }

        public double CountPenalty(DateTime currDate)
        {
            if (balance < 0)
            {
                double start = balance;
                int months = CountMonths(currDate, penalty_start_date);

                for (int i = 0; i < months; i++)
                    balance *= (1.0 + interest_rate / 100.0);

                if (months > 0)
                {
                    int day = penalty_start_date.Day;
                    penalty_start_date = new DateTime(currDate.Year, currDate.Month, day);
                }

                double difference = start - balance;
                return difference;
            }
            else
                return 0;
        }
        
        public override double CheckBalance(DateTime currDate)
        {
            CountPenalty(currDate);
            return balance;
        }

        public override void PutMoney(double sum, DateTime currDate)
        {
            balance += sum;
            CountPenalty(currDate);
        }

        public override double WithdrawMoney(double sum, DateTime currDate)
        {
            double startBalance = balance;
            balance -= sum;
            if (balance < 0)
                if (startBalance > 0)
                    penalty_start_date = currDate;

            CountPenalty(currDate);
            return sum;
        }
    }
}

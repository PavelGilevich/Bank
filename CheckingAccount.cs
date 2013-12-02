using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class CheckingAccount:UniversalAccount
    {
        int monthly_quota;
        int total_transactions;
        double per_transaction_fee;
        DateTime operationDate;

        public CheckingAccount() {}
        public CheckingAccount(int number, string password, double balance, DateTime openDate, int monthlyQuota, double fee)
        {
            this.number = number;
            this.password = password;
            this.balance = balance;
            this.openDate = openDate;
            this.operationDate = openDate;
            this.monthly_quota = monthlyQuota;
            this.total_transactions = 0;
            this.per_transaction_fee = fee;
        }

        public double CheckFee()
        {
            if (total_transactions > monthly_quota)
            {
                balance -= per_transaction_fee;
                return per_transaction_fee;
            }
            else
                return 0;
            
        }

        public override void PutMoney(double sum, DateTime currDate)
        {
            balance += sum;
            if (CountMonths(currDate, operationDate) == 0)
            {
                total_transactions++;
                CheckFee();
            }
            else
            {
                operationDate = new DateTime(currDate.Year, currDate.Month, openDate.Day);
                total_transactions++;
            }
        }

        public override double WithdrawMoney(double sum, DateTime currDate)
        {
            if (CountMonths(currDate, operationDate) == 0)
            {
                total_transactions++;
                CheckFee();
            }
            
            if (sum > balance)
            {
                Console.WriteLine("Not enough money");
                total_transactions--;
                balance += per_transaction_fee;
                return 0;
            }
            else
            {
                balance -= sum;
                return sum;
            }
        }

        public override double CheckBalance(DateTime currDate)
        {
            return balance;
        }
    }
}

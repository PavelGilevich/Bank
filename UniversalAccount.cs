using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    abstract class UniversalAccount   
    {
        protected int number;                   //account's number
        protected String password;              //account's password
        protected double balance;               //current balance
        protected DateTime openDate;            //account's opening date

        //abstract methods
        public abstract void PutMoney(double sum, DateTime currDate);
        public abstract double WithdrawMoney(double sum, DateTime currDate);
        public abstract double CheckBalance(DateTime currDate);

        //method CountMonths calculates the number of months between 2 dates
        public int CountMonths(DateTime currentDate, DateTime paymentDate)
        {
            int months = (currentDate.Year - paymentDate.Year) * 12 + (currentDate.Month - paymentDate.Month);
            if (currentDate.Day < paymentDate.Day)
                months--;
            return months;
        }

        public int Number
        {
            get { return number; }
        }
        public String Password
        {
            get { return password; }
        }
    }
}

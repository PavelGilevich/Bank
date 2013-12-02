using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class Program
    {
        static List<UniversalAccount> Accounts;                 //list of created accounts
        static UniversalAccount SearchByLogin(int number)       //searches account by its login
        {
            foreach(UniversalAccount acc in Accounts)
                if (acc.Number == number)
                    return acc;
           
            return null;
        }

        static void Main(string[] args)
        {
            Accounts = new List<UniversalAccount>();
            for(;;)
            {
                //start menu
                Console.Write("1 - Create Account\n2 - Enter account menu\n0 - Exit\nInput key: "); 
                int key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Console.WriteLine("Select account's type\n1 - Savings account\n2 - Timed Maturity Account\n3 - Checking Account");
                        Console.Write("4 - Overdraft account\nInput key: ");
                        int acc_key;
                        acc_key = Convert.ToInt32(Console.ReadLine());
                        int acc_number;
                        for (; ;)
                        {
                            Console.Write("Enter number: "); acc_number = Convert.ToInt32(Console.ReadLine());
                            if (SearchByLogin(acc_number) != null)
                            {
                                Console.WriteLine("Account with this number already exists. Try again");
                            }
                            else
                                break;
                        }

                        Console.Write("Enter pasword: "); String acc_password = Console.ReadLine();
                        Console.Write("Enter date (use \" - \"): "); String date = Console.ReadLine();
                        String[] split_date = date.Split('-');
                        DateTime acc_date = new DateTime(Convert.ToInt32(split_date[2]), Convert.ToInt32(split_date[1]), Convert.ToInt32(split_date[0]));
                        Console.Write("Enter start balance: "); double acc_balance = Convert.ToDouble(Console.ReadLine());

                        switch (acc_key)
                        {
                            case 1:
                                Console.Write("Enter interest rate: "); double acc_rate = Convert.ToDouble(Console.ReadLine());
                                SavingsAccount savings_acc = new SavingsAccount(acc_number, acc_password, acc_balance, acc_rate, acc_date);
                                Accounts.Add(savings_acc);
                                Console.WriteLine("New Savings Account was created\n---------------------");
                                break;
                            case 2:
                                Console.Write("Enter interest rate: "); acc_rate = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter penalty rate: "); double acc_penaltyrate = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter period (in months): "); int acc_period = Convert.ToInt32(Console.ReadLine());
                                TimedMaturityAccount timed_acc = new TimedMaturityAccount(acc_number, acc_password, acc_balance, acc_rate,
                                    acc_date, acc_penaltyrate, acc_period);
                                Accounts.Add(timed_acc);
                                Console.WriteLine("New Timed Maturity Account was created\n---------------------");
                                break;
                            case 3:
                                Console.Write("Enter number of operations allowed to perform during one month: ");
                                int acc_monthquota = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Enter fee: "); double acc_fee = Convert.ToDouble(Console.ReadLine());
                                CheckingAccount checking_acc = new CheckingAccount(acc_number, acc_password, acc_balance, acc_date,
                                    acc_monthquota, acc_fee);
                                Accounts.Add(checking_acc);
                                Console.WriteLine("New Checking Account was created\n---------------------");
                                break;
                            case 4:
                                Console.Write("Enter rate: "); acc_rate = Convert.ToDouble(Console.ReadLine());
                                OverdraftAccount overdraft_acc = new OverdraftAccount(acc_number, acc_password, acc_balance, acc_date,
                                    acc_rate);
                                Accounts.Add(overdraft_acc);
                                Console.WriteLine("New Overdraft Account was created\n---------------------");
                                break;
                        }
                        break;

                    case 2:
                        UniversalAccount search_result;
                        //searching existing account
                        for (; ; )
                        {
                            Console.Write("Enter account's number: "); int number = Convert.ToInt32(Console.ReadLine());
                            search_result = SearchByLogin(number);
                            if (search_result == null)
                                Console.WriteLine("Account was not found. Try again.");
                            else
                                break;
                        }
                        for (; ;)
                        {
                            Console.Write("Enter password: ");
                            if (!(Console.ReadLine().Equals(search_result.Password)))
                                Console.WriteLine("Wrong password. Try again.");
                            else
                                break;
                        }

                        //account's menu
                        Console.WriteLine("------------\nACCOUNT'S № " + search_result.Number+ " MENU\n--------------");
                        for (; ; )
                        {
                            Console.WriteLine("1 - Put Money\n2 - Withdraw Money\n3 - Check Balance\n0 - Exit account\nInput key: ");
                            int key_menu = Convert.ToInt32(Console.ReadLine());
                            switch (key_menu)
                            {
                                case 1:
                                    Console.Write("Enter sum to put: ");
                                    double put_sum = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Enter today's date (use \"-\"): ");
                                    split_date = Console.ReadLine().Split('-');
                                    search_result.PutMoney(put_sum, new DateTime(Convert.ToInt32(split_date[2]),
                                        Convert.ToInt32(split_date[1]), Convert.ToInt32(split_date[0])));

                                    Console.WriteLine("The money has been added");
                                    break;

                                case 2:
                                    Console.Write("Enter sum to withdraw: ");
                                    double sum = Convert.ToDouble(Console.ReadLine());
                                    Console.Write("Enter today's date (use \"-\"): ");
                                    split_date = Console.ReadLine().Split('-');
                                    search_result.WithdrawMoney(sum, new DateTime(Convert.ToInt32(split_date[2]),
                                        Convert.ToInt32(split_date[1]), Convert.ToInt32(split_date[0])));
                                    Console.WriteLine("The money has been withdrawn");
                                    break;

                                case 3:
                                    Console.Write("Enter today's date (use \"-\"): ");
                                    split_date = Console.ReadLine().Split('-');

                                    Console.WriteLine("Current balance is {0}", search_result.CheckBalance(new DateTime(Convert.ToInt32(split_date[2]),
                                        Convert.ToInt32(split_date[1]), Convert.ToInt32(split_date[0]))));
                                    break;

                                default:
                                    break;
                            }
                            if (key_menu == 0)
                                break;
                        }
                        break;

                    case 0:
                        return;
                }
            }          
        }
    }
}

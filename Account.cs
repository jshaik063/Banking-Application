using System;

    public class Account
    {
        public long AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public double Balance { get; set; }

        // Event declarations
       // public delegate void EventHandler1(double amount);
        public  EventHandler UnderBalance;
        //public delegate void EventHandler2();
        public  EventHandler BalanceZero;

        // Constructor
        public Account(long accountNumber, string customerName, double initialBalance)
        {
            this.AccountNumber = accountNumber;
            this.CustomerName = customerName;
            this.Balance = initialBalance;
        }

     
        public void Deposit(double amount)
        {
            
            Balance += amount;
            Console.WriteLine($"Deposited {amount} rupees successfully. New balance: {Balance}");
        }


        public void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawn {amount} rupees successfully. New balance: {Balance}");
                if (Balance < 100&&Balance!=0) 
                {
                        // Assuming 100 as the threshold for under balance
                        UnderBalance.Invoke(this, EventArgs.Empty);
                       // UnderBalance?.Invoke(Balance);
                }
                if (Balance ==0) 
                {
                       // BalanceZero?.Invoke();
                       BalanceZero.Invoke(this, EventArgs.Empty);

                }

            }
            else
            {
                Console.WriteLine($"Insufficient balance in account {AccountNumber}");
            }
                  


            
        }
    }

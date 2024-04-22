
public delegate void Debit(double a);
public delegate void Credit(double a);

class Program
    {
        static void Main(string[] args)
        {
            Account a = new Account(62486727598, "Jafar Shaik", 500);

            Console.WriteLine("Name: " + a.CustomerName);
            Console.WriteLine("Account Number: " + a.AccountNumber);
            Console.WriteLine("Current balance: " + a.Balance );

            
            //a.UnderBalance += (Balance) => Console.WriteLine($"Balance is below 100. Current balance: {Balance}");
           // a.BalanceZero += () => Console.WriteLine("Balance reached zero!");
          a.UnderBalance += (object sender, EventArgs e) => Console.WriteLine($"The balance is under 100");
          a.BalanceZero += (object sender, EventArgs e) => Console.WriteLine($"The balance has reached to zero");

           // a.Deposit(1000);
            //a.Withdraw(1500);
            Credit cr= a.Deposit;
            cr(1000);
            Debit db = a.Withdraw;
            db(500);
            db(950);
            
            

           
        }
        
       
    }















//  static void UnderBalanceHandler(object sender, EventArgs e)
//         {
//             Console.WriteLine("Balance is under the minimum threshold!");
//         }

//         static void BalanceZeroHandler(object sender, EventArgs e)
//         {
//             Console.WriteLine("Balance has reached zero!");
//         }
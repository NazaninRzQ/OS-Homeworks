using System;
using System.Threading;

class Program
{
    static readonly object lockObject = new object(); 
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(WithdrawMoney);
            thread.Start(i + 1);
        }
    
    }

    static void WithdrawMoney(object accountId)
    {
        lock (lockObject)
        {
            Console.WriteLine($"Account {accountId} is withdrawing money...");
            Thread.Sleep(2000); 
            Console.WriteLine($"Account {accountId} has withdrawn money.");
            
        } 
    }
}

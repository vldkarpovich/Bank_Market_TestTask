using Newtonsoft.Json;
using System.Net;

namespace Market
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var transactionWorker = new TransactionWorker();
            Console.WriteLine("Market start work");
            Console.WriteLine("Please press Enter if you want buy samething or prees another key if want exit");

            while (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                await transactionWorker.SendtransactionAsync();
                Console.WriteLine("Please press Enter if you want buy samething again or prees another key if want exit");
            }
        }
    }
}
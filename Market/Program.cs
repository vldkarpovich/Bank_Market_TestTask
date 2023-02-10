namespace Market
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var transactionWorker = new TransactionWorker();

            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback();
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 2000);

            var result = await transactionWorker.SendtransactionAsync();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
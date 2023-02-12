using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Market
{
    public class TransactionWorker
    {
        public async Task SendtransactionAsync()
        {
            var result = "";
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                Random rnd = new Random();
                var transaction = new Transaction() { Sum = rnd.Next(500, 2000), CardNumber = "4569403961014710" };
                Console.WriteLine($"Send transaction, sum = {transaction.Sum.ToString()}");
                var response = await client.PostAsync("https://localhost:44304/api/create-order", new StringContent(JsonConvert.SerializeObject(transaction), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var transactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(await response.Content.ReadAsStringAsync());
                    result = transactionResponse.TransactionStatus.ToString();

                    Console.WriteLine($"Transaction was sended, transaction status - {result}");

                    while (result == "InProces")
                    {
                        Task.Delay(2000).Wait();
                        Console.WriteLine($"Get transaction status");
                        var getResponse = await client.GetAsync("https://localhost:44304/api/get-status?id=" + $"{transactionResponse.Id.ToString()}");
                        getResponse.EnsureSuccessStatusCode();

                        if (getResponse != null && getResponse.StatusCode == HttpStatusCode.OK)
                        {
                            var getTransactionResponse = JsonConvert.DeserializeObject<TransactionResponse>(await getResponse.Content.ReadAsStringAsync());
                            result = getTransactionResponse.TransactionStatus.ToString();
                        }
                    }

                    if (result == "Accept")
                        Console.WriteLine($"Transaction status was changed, transaction status - {result}");

                    if (result == "Fail")
                        Console.WriteLine($"Transaction status was changed, transaction status - {result}");
                }
            }
        }
    }
}

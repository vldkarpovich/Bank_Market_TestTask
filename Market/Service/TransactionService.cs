using Market.Interfaces;
using Market.Models;
using Market.Views;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.Text;

namespace Market.Service
{
    public class TransactionService : ITransactionService
    {
        public async Task SendtransactionAsync()
        {
            var response = await CreateAndSendTransaction();

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var responseResult = await GetResponseResult(response);

                await HandleResponse(responseResult);
            }
        }

        private async Task<HttpResponseMessage> CreateAndSendTransaction()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var url = ConfigurationManager.AppSettings["postTransactionUrl"];
            using (var client = new HttpClient(clientHandler))
            {
                var transaction = new Transaction() { Sum = GetRandomAmount(), CardNumber = "4569403961014710" };
                Console.WriteLine($"Send transaction, sum = {transaction.Sum.ToString()}");
                var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(transaction), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                return response;
            }
        }

        private async Task HandleResponse(TransactionResponse transactionResponse)
        {
            Console.WriteLine($"Transaction was sended, transaction status - {transactionResponse.TransactionStatus.ToString()}");

            while (transactionResponse.TransactionStatus == TransactionStatus.InProcess)
            {
                transactionResponse.TransactionStatus = await HandleInProcessResult(transactionResponse.Id.ToString());
            }

            if (transactionResponse.TransactionStatus == TransactionStatus.Accept)
                Console.WriteLine($"Transaction status was changed, transaction status - {transactionResponse.TransactionStatus}");

            if (transactionResponse.TransactionStatus == TransactionStatus.Fail)
                Console.WriteLine($"Transaction status was changed, transaction status - {transactionResponse.TransactionStatus}");
        }

        private async Task<TransactionStatus> HandleInProcessResult(string id)
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var url = ConfigurationManager.AppSettings["getTransactionUrl"];
            using (var client = new HttpClient(clientHandler))
            {
                Task.Delay(2000).Wait();
                Console.WriteLine($"Get transaction status");
                var getResponse = await client.GetAsync(url + $"{id}");
                getResponse.EnsureSuccessStatusCode();

                if (getResponse != null && getResponse.StatusCode == HttpStatusCode.OK)
                {
                    var result = await GetResponseResult(getResponse);
                    return result.TransactionStatus;
                }
                return TransactionStatus.Fail;
            }
        }

        private async Task<TransactionResponse> GetResponseResult(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<TransactionResponse>(await response.Content.ReadAsStringAsync());
        }

        private double GetRandomAmount()
        {
            Random rnd = new Random();
            return Math.Round(rnd.NextDouble() * (2000 - 500) + 500, 2);
        }
    }
}

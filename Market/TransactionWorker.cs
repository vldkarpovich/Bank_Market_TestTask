using System.Net;
using System.Text;
using System.Text.Json;

namespace Market
{
    public class TransactionWorker
    {



        public async Task<string> SendtransactionAsync()
        {
            var result = "";
            var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                Random rnd = new Random();
                var transaction = new Transaction() { Sum = rnd.Next(500, 2000), CardNumber = "4569403961014710" };
                var response = await client.PostAsync("https://localhost:44304/api/create-order", new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var transactionResponse = JsonSerializer.Deserialize<TransactionResponse>(await response.Content.ReadAsStringAsync());
                    result = transactionResponse.TransactionStatus.ToString();

                    //using (var stream = new StreamReader(await response.Content.ReadAsStreamAsync()))
                    //{
                    //    reader = new JsonTextReader(stream);
                    //    result = new Newtonsoft.Json.JsonSerializer().Deserialize<string>(reader);
                    //}
                }
            }
            return result;
        }
    }
}

using System.Text.Json.Serialization;

namespace Bank.EFModels.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionStatus : int { InProces = 1, Accept = 2, Fail = 3 }
}

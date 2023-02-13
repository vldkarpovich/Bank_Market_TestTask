using System.Text.Json.Serialization;

namespace Bank.EFModels.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionStatus : int { InProcess = 1, Accept = 2, Fail = 3 }
}

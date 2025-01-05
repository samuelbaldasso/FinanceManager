using System.Text.Json.Serialization;

namespace WebApplication1.Entities
{
    public enum TransactionType
    {
         [JsonPropertyName("Gain")]
         Gain,
         [JsonPropertyName("Spend")]
         Spend
    }
}
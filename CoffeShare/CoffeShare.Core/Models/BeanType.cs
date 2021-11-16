using System.Text.Json.Serialization;

namespace CoffeeShare.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BeanType
    {
        Arabica,
        Robusta
    }
}

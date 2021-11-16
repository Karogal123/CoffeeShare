using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CoffeeShare.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BeansProcessing
    {
        Dry,
        Washed,
        Honey
    }
}

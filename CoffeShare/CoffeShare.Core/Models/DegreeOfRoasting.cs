using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace CoffeeShare.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DegreeOfRoasting
    {
        Light,
        Medium,
        Dark 
    }
}

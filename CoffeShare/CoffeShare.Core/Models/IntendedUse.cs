using System.Text.Json.Serialization;

namespace CoffeeShare.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IntendedUse
    {
        Espresso,
        Aeropress,
        FrenchPress,
        Chemex,
        Dripper,
        MokaPot
    }
}

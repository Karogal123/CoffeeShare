using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoffeeShare.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GrindLevel
    {
        Coarse,
        Fine
    }
}

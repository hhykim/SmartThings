using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartThings.Dtos.Requests
{
    internal class Body
    {
        public List<Command> Commands { get; set; }
    }

    internal class Command
    {
        public string Capability { get; set; }

        [JsonPropertyName("command")]
        public string Action { get; set; }
    }
}

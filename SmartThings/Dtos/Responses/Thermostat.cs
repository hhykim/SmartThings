using System;
using System.Text.Json;

namespace SmartThings.Dtos.Responses
{
    internal class Thermostat
    {
        public JsonElement CoolingSetpointRange { get; set; }
        public CoolingSetpoint CoolingSetpoint { get; set; }
    }

    internal class CoolingSetpoint
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}

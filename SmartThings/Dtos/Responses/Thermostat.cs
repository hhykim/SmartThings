namespace SmartThings.Dtos.Responses
{
    internal class Thermostat
    {
        public CoolingSetpointRange CoolingSetpointRange { get; set; }
        public CoolingSetpoint CoolingSetpoint { get; set; }
    }

    internal class CoolingSetpointRange
    {
        public object Value { get; set; }
    }

    internal class CoolingSetpoint
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public string Timestamp { get; set; }
    }
}

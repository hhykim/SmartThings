namespace SmartThings.Dtos.Responses
{
    internal class Power
    {
        public Switch Switch { get; set; }
    }

    internal class Switch
    {
        public string Value { get; set; }
        public string Timestamp { get; set; }
    }
}

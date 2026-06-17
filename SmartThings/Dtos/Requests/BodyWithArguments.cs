using System.Collections.Generic;

namespace SmartThings.Dtos.Requests
{
    internal class BodyWithArguments
    {
        public List<CommandWithArguments> Commands { get; set; }
    }

    internal class CommandWithArguments : Command
    {
        public List<int> Arguments { get; set; }
    }
}

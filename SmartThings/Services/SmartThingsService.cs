using RestSharp;
using RestSharp.Authenticators;
using SmartThings.Dtos.Requests;
using SmartThings.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartThings.Services
{
    internal class SmartThingsService
    {
        private const string Url = "https://api.smartthings.com/v1/devices";  // TODO: Add device ID.
        private const string Token = "";  // TODO: Add personal access token.

        private readonly RestClient client;

        public SmartThingsService()
        {
            var options = new RestClientOptions
            {
                Authenticator = new JwtAuthenticator(Token)
            };
            client = new RestClient(options);
        }

        public async Task<bool> IsPowerOnAsync()
        {
            string url = $"{Url}/components/main/capabilities/switch/status";
            Power power = await client.GetAsync<Power>(url);

            return power.Switch.Value == "on";
        }

        public async Task SetPowerAsync(bool powerOn)
        {
            var request = new RestRequest($"{Url}/commands");
            var param = new Body
            {
                Commands = new List<Command>
                {
                    new Command
                    {
                        Capability = "switch",
                        Action = powerOn ? "on" : "off"
                    }
                }
            };

            request.AddJsonBody(param);
            await client.PostAsync(request);
        }

        public async Task<int> GetTemperatureAsync()
        {
            string url = $"{Url}/components/main/capabilities/thermostatCoolingSetpoint/status";
            Thermostat thermostat = await client.GetAsync<Thermostat>(url);

            return thermostat.CoolingSetpoint.Value;
        }

        public async Task SetTemperatureAsync(int temperature)
        {
            var request = new RestRequest($"{Url}/commands");
            var param = new BodyWithArguments
            {
                Commands = new List<CommandWithArguments>
                {
                    new CommandWithArguments
                    {
                        Capability = "thermostatCoolingSetpoint",
                        Action = "setCoolingSetpoint",
                        Arguments = new List<int>
                        {
                            temperature
                        }
                    }
                }
            };

            request.AddJsonBody(param);
            await client.PostAsync(request);
        }
    }
}

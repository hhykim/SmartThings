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
        private readonly RestClient _client;
        private readonly string _baseUrl;

        public SmartThingsService()
        {
            Properties.Settings settings = Properties.Settings.Default;

            var options = new RestClientOptions
            {
                Authenticator = new JwtAuthenticator(settings.PersonalAccessToken)
            };
            _client = new RestClient(options);

            _baseUrl = $"https://api.smartthings.com/v1/devices/{settings.DeviceId}";
        }

        public async Task<bool> IsPowerOnAsync()
        {
            var url = $"{_baseUrl}/components/main/capabilities/switch/status";
            Power power = await _client.GetAsync<Power>(url);

            return power.Switch.Value == "on";
        }

        public async Task SetPowerAsync(bool powerOn)
        {
            var request = new RestRequest($"{_baseUrl}/commands");
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
            await _client.PostAsync(request);
        }

        public async Task<int> GetTemperatureAsync()
        {
            var url = $"{_baseUrl}/components/main/capabilities/thermostatCoolingSetpoint/status";
            Thermostat thermostat = await _client.GetAsync<Thermostat>(url);

            return thermostat.CoolingSetpoint.Value;
        }

        public async Task SetTemperatureAsync(int temperature)
        {
            var request = new RestRequest($"{_baseUrl}/commands");
            var param = new BodyWithArguments
            {
                Commands = new List<CommandWithArguments>
                {
                    new CommandWithArguments
                    {
                        Capability = "thermostatCoolingSetpoint",
                        Action = "setCoolingSetpoint",
                        Arguments = new List<object>
                        {
                            temperature
                        }
                    }
                }
            };

            request.AddJsonBody(param);
            await _client.PostAsync(request);
        }
    }
}

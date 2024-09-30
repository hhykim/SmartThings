using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartThings
{
    public partial class SmartThings : Form
    {
        private const string Url = "https://api.smartthings.com/v1/devices";  // TODO: Add device ID.
        private const string Token = "";  // TODO: Add personal access token.

        private readonly RestClientOptions options;
        private readonly RestClient client;

        public SmartThings()
        {
            InitializeComponent();

            options = new RestClientOptions
            {
                Authenticator = new JwtAuthenticator(Token)
            };
            client = new RestClient(options);
            
            Deactivate += (s, e) =>
            {
                SetControlsState(false);
                if (WindowState != FormWindowState.Minimized)
                {
                    Activated += new EventHandler(SmartThings_Activated);
                }
            };
            Resize += (s, e) =>
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    SmartThings_Activated(s, e);
                }
            };

            power.Click += async (s, e) =>
            {
                SetControlsState(false);

                string name;
                if (power.Checked)
                {
                    name = "on";
                }
                else
                {
                    name = "off";
                }
                
                var request = new RestRequest($"{Url}/commands");
                var param = new Body
                {
                    commands = new List<Command>
                    {
                        new Command
                        {
                            capability = "switch",
                            command = name
                        }
                    }
                };

                request.AddJsonBody(param);
                await client.PostAsync(request);
            };
        }

        private async void SmartThings_Activated(object sender, EventArgs e)
        {
            thermostatCoolingSetpoint.ValueChanged -= new EventHandler(thermostatCoolingSetpoint_ValueChanged);
            await UpdateControlsState();
            thermostatCoolingSetpoint.ValueChanged += new EventHandler(thermostatCoolingSetpoint_ValueChanged);

            Activated -= new EventHandler(SmartThings_Activated);
        }

        private async void thermostatCoolingSetpoint_ValueChanged(object sender, EventArgs e)
        {
            SetControlsState(false);

            var request = new RestRequest($"{Url}/commands");
            var param = new BodyWithArguments
            {
                commands = new List<CommandWithArguments>
                {
                    new CommandWithArguments
                    {
                        capability = "thermostatCoolingSetpoint",
                        command = "setCoolingSetpoint",
                        arguments = new List<int>
                        {
                            (int)thermostatCoolingSetpoint.Value
                        }
                    }
                }
            };

            request.AddJsonBody(param);
            await client.PostAsync(request);
        }

        private async Task UpdateControlsState()
        {
            string url = $"{Url}/components/main/capabilities";

            Thermostat thermostat = await client.GetAsync<Thermostat>($"{url}/thermostatCoolingSetpoint/status");
            thermostatCoolingSetpoint.Value = thermostat.coolingSetpoint.value;

            Power power = await client.GetAsync<Power>($"{url}/switch/status");
            if (power.@switch.value == "on")
            {
                this.power.Checked = true;
            }
            else
            {
                this.power.Checked = false;
            }

            SetControlsState(true);
        }

        private void SetControlsState(bool state)
        {
            if (state)
            {
                if (power.Checked)
                {
                    thermostat.Enabled = true;
                    thermostatCoolingSetpoint.Enabled = true;
                }
                power.Enabled = true;
            }
            else
            {
                thermostat.Enabled = false;
                thermostatCoolingSetpoint.Enabled = false;
                power.Enabled = false;
            }
        }

        private class Thermostat
        {
            public CoolingSetpointRange coolingSetpointRange { get; set; }
            public CoolingSetpoint coolingSetpoint { get; set; }
        }
        private class CoolingSetpointRange
        {
            public object value { get; set; }
        }
        private class CoolingSetpoint
        {
            public int value { get; set; }
            public string unit { get; set; }
            public string timestamp { get; set; }
        }

        private class Power
        {
            public Switch @switch { get; set; }
        }
        private class Switch
        {
            public string value { get; set; }
            public string timestamp { get; set; }
        }

        private class Body
        {
            public List<Command> commands { get; set; }
        }
        private class Command
        {
            public string capability { get; set; }
            public string command { get; set; }
        }

        private class BodyWithArguments
        {
            public List<CommandWithArguments> commands { get; set; }
        }
        private class CommandWithArguments : Command
        {
            public List<int> arguments { get; set; }
        }
    }
}

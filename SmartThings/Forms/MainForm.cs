using SmartThings.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartThings.Forms
{
    public partial class MainForm : Form
    {
        private readonly SmartThingsService service;

        public MainForm()
        {
            InitializeComponent();

            service = new SmartThingsService();
            
            Deactivate += (s, e) =>
            {
                SetControlsState(false);
                if (WindowState != FormWindowState.Minimized)
                {
                    Activated += new EventHandler(MainForm_Activated);
                }
            };
            Resize += (s, e) =>
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    MainForm_Activated(s, e);
                }
            };

            PowerCheckBox.Click += async (s, e) =>
            {
                SetControlsState(false);
                await service.SetPowerAsync(PowerCheckBox.Checked);
            };
        }

        private async void MainForm_Activated(object sender, EventArgs e)
        {
            TemperatureUpDown.ValueChanged -= new EventHandler(TemperatureUpDown_ValueChanged);
            await UpdateControlsState();
            TemperatureUpDown.ValueChanged += new EventHandler(TemperatureUpDown_ValueChanged);

            Activated -= new EventHandler(MainForm_Activated);
        }

        private async void TemperatureUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetControlsState(false);
            await service.SetTemperatureAsync((int)TemperatureUpDown.Value);
        }

        private async Task UpdateControlsState()
        {
            TemperatureUpDown.Value = await service.GetTemperatureAsync();
            PowerCheckBox.Checked = await service.IsPowerOnAsync();

            SetControlsState(true);
        }

        private void SetControlsState(bool state)
        {
            if (state)
            {
                if (PowerCheckBox.Checked)
                {
                    TemperatureLabel.Enabled = true;
                    TemperatureUpDown.Enabled = true;
                }
                PowerCheckBox.Enabled = true;
            }
            else
            {
                TemperatureLabel.Enabled = false;
                TemperatureUpDown.Enabled = false;
                PowerCheckBox.Enabled = false;
            }
        }
    }
}

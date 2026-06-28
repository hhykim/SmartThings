using SmartThings.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartThings.Forms
{
    public partial class MainForm : Form
    {
        private readonly SmartThingsService _service;
        private bool _isUpdating;

        public MainForm()
        {
            InitializeComponent();

            _service = new SmartThingsService();

            Deactivate += (s, e) => SetControlsState(false);
            Shown += async (s, e) => await ExecuteAsync(UpdateControlsState);

            AirconPictureBox.Click += async (s, e) =>
            {
                if (PowerCheckBox.Enabled) return;
                await ExecuteAsync(UpdateControlsState);
            };

            PowerCheckBox.Click += async (s, e) =>
            {
                await ExecuteAsync(() => _service.SetPowerAsync(PowerCheckBox.Checked));
            };
        }

        private async void TemperatureUpDown_ValueChanged(object sender, EventArgs e)
        {
            await ExecuteAsync(() => _service.SetTemperatureAsync((int)TemperatureUpDown.Value));
        }

        private async Task UpdateControlsState()
        {
            TemperatureUpDown.ValueChanged -= new EventHandler(TemperatureUpDown_ValueChanged);
            try
            {
                TemperatureUpDown.Value = await _service.GetTemperatureAsync();
                PowerCheckBox.Checked = await _service.IsPowerOnAsync();
            }
            finally
            {
                TemperatureUpDown.ValueChanged += new EventHandler(TemperatureUpDown_ValueChanged);
            }

            SetControlsState(true);
        }

        private void SetControlsState(bool state)
        {
            if (state)
            {
                AirconPictureBox.Cursor = Cursors.Default;
                if (PowerCheckBox.Checked)
                {
                    TemperatureLabel.Enabled = true;
                    TemperatureUpDown.Enabled = true;
                }
                PowerCheckBox.Enabled = true;
            }
            else
            {
                AirconPictureBox.Cursor = _isUpdating ? Cursors.WaitCursor : Cursors.Hand;
                TemperatureLabel.Enabled = false;
                TemperatureUpDown.Enabled = false;
                PowerCheckBox.Enabled = false;
            }
        }

        private async Task ExecuteAsync(Func<Task> action)
        {
            if (_isUpdating) return;

            _isUpdating = true;
            try
            {
                SetControlsState(false);
                await action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isUpdating = false;
                if (!PowerCheckBox.Enabled)
                {
                    AirconPictureBox.Cursor = Cursors.Hand;
                }
            }
        }
    }
}

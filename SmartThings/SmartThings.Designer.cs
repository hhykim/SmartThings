namespace SmartThings
{
    partial class SmartThings
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartThings));
            this.aircon = new System.Windows.Forms.PictureBox();
            this.thermostat = new System.Windows.Forms.Label();
            this.thermostatCoolingSetpoint = new System.Windows.Forms.NumericUpDown();
            this.power = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.aircon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermostatCoolingSetpoint)).BeginInit();
            this.SuspendLayout();
            // 
            // aircon
            // 
            this.aircon.Image = global::SmartThings.Properties.Resources.aircon;
            this.aircon.Location = new System.Drawing.Point(12, 12);
            this.aircon.Name = "aircon";
            this.aircon.Size = new System.Drawing.Size(314, 100);
            this.aircon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.aircon.TabIndex = 0;
            this.aircon.TabStop = false;
            // 
            // thermostat
            // 
            this.thermostat.AutoSize = true;
            this.thermostat.Enabled = false;
            this.thermostat.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.thermostat.Location = new System.Drawing.Point(60, 41);
            this.thermostat.Name = "thermostat";
            this.thermostat.Size = new System.Drawing.Size(42, 21);
            this.thermostat.TabIndex = 1;
            this.thermostat.Text = "온도";
            // 
            // thermostatCoolingSetpoint
            // 
            this.thermostatCoolingSetpoint.Enabled = false;
            this.thermostatCoolingSetpoint.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.thermostatCoolingSetpoint.Location = new System.Drawing.Point(108, 39);
            this.thermostatCoolingSetpoint.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.thermostatCoolingSetpoint.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.thermostatCoolingSetpoint.Name = "thermostatCoolingSetpoint";
            this.thermostatCoolingSetpoint.ReadOnly = true;
            this.thermostatCoolingSetpoint.Size = new System.Drawing.Size(58, 29);
            this.thermostatCoolingSetpoint.TabIndex = 2;
            this.thermostatCoolingSetpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.thermostatCoolingSetpoint.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.thermostatCoolingSetpoint.ValueChanged += new System.EventHandler(this.thermostatCoolingSetpoint_ValueChanged);
            // 
            // power
            // 
            this.power.AutoSize = true;
            this.power.Enabled = false;
            this.power.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.power.Location = new System.Drawing.Point(220, 40);
            this.power.Name = "power";
            this.power.Size = new System.Drawing.Size(61, 25);
            this.power.TabIndex = 3;
            this.power.Text = "전원";
            this.power.UseVisualStyleBackColor = true;
            // 
            // SmartThings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(338, 124);
            this.Controls.Add(this.power);
            this.Controls.Add(this.thermostatCoolingSetpoint);
            this.Controls.Add(this.thermostat);
            this.Controls.Add(this.aircon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SmartThings";
            this.Text = "SmartThings";
            this.Activated += new System.EventHandler(this.SmartThings_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.aircon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thermostatCoolingSetpoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox aircon;
        private System.Windows.Forms.Label thermostat;
        private System.Windows.Forms.NumericUpDown thermostatCoolingSetpoint;
        private System.Windows.Forms.CheckBox power;
    }
}


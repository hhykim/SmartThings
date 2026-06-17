namespace SmartThings.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AirconPictureBox = new System.Windows.Forms.PictureBox();
            this.TemperatureLabel = new System.Windows.Forms.Label();
            this.TemperatureUpDown = new System.Windows.Forms.NumericUpDown();
            this.PowerCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.AirconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // AirconPictureBox
            // 
            this.AirconPictureBox.Image = global::SmartThings.Properties.Resources.aircon;
            this.AirconPictureBox.Location = new System.Drawing.Point(12, 12);
            this.AirconPictureBox.Name = "AirconPictureBox";
            this.AirconPictureBox.Size = new System.Drawing.Size(314, 100);
            this.AirconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AirconPictureBox.TabIndex = 0;
            this.AirconPictureBox.TabStop = false;
            // 
            // TemperatureLabel
            // 
            this.TemperatureLabel.AutoSize = true;
            this.TemperatureLabel.Enabled = false;
            this.TemperatureLabel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TemperatureLabel.Location = new System.Drawing.Point(60, 41);
            this.TemperatureLabel.Name = "TemperatureLabel";
            this.TemperatureLabel.Size = new System.Drawing.Size(42, 21);
            this.TemperatureLabel.TabIndex = 1;
            this.TemperatureLabel.Text = "온도";
            // 
            // TemperatureUpDown
            // 
            this.TemperatureUpDown.Enabled = false;
            this.TemperatureUpDown.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TemperatureUpDown.Location = new System.Drawing.Point(108, 39);
            this.TemperatureUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.TemperatureUpDown.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.TemperatureUpDown.Name = "TemperatureUpDown";
            this.TemperatureUpDown.ReadOnly = true;
            this.TemperatureUpDown.Size = new System.Drawing.Size(58, 29);
            this.TemperatureUpDown.TabIndex = 2;
            this.TemperatureUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TemperatureUpDown.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.TemperatureUpDown.ValueChanged += new System.EventHandler(this.TemperatureUpDown_ValueChanged);
            // 
            // PowerCheckBox
            // 
            this.PowerCheckBox.AutoSize = true;
            this.PowerCheckBox.Enabled = false;
            this.PowerCheckBox.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PowerCheckBox.Location = new System.Drawing.Point(220, 40);
            this.PowerCheckBox.Name = "PowerCheckBox";
            this.PowerCheckBox.Size = new System.Drawing.Size(61, 25);
            this.PowerCheckBox.TabIndex = 3;
            this.PowerCheckBox.Text = "전원";
            this.PowerCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(338, 124);
            this.Controls.Add(this.PowerCheckBox);
            this.Controls.Add(this.TemperatureUpDown);
            this.Controls.Add(this.TemperatureLabel);
            this.Controls.Add(this.AirconPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SmartThings";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.AirconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AirconPictureBox;
        private System.Windows.Forms.Label TemperatureLabel;
        private System.Windows.Forms.NumericUpDown TemperatureUpDown;
        private System.Windows.Forms.CheckBox PowerCheckBox;
    }
}


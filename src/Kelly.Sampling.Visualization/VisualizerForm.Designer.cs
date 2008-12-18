namespace Kelly.Sampling.Visualization {
	partial class VisualizerForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.imageContainer = new System.Windows.Forms.PictureBox();
			this.regenerate = new System.Windows.Forms.Button();
			this.randomNumberGenerators = new System.Windows.Forms.ComboBox();
			this.sampleCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.sampleGenerators = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.centerBiasDisplay = new System.Windows.Forms.Label();
			this.centerBiasSlider = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.biasTowardsCenter = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.imageContainer)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.centerBiasSlider)).BeginInit();
			this.SuspendLayout();
			// 
			// imageContainer
			// 
			this.imageContainer.Location = new System.Drawing.Point(12, 12);
			this.imageContainer.Name = "imageContainer";
			this.imageContainer.Size = new System.Drawing.Size(512, 512);
			this.imageContainer.TabIndex = 0;
			this.imageContainer.TabStop = false;
			// 
			// regenerate
			// 
			this.regenerate.Location = new System.Drawing.Point(8, 254);
			this.regenerate.Name = "regenerate";
			this.regenerate.Size = new System.Drawing.Size(167, 23);
			this.regenerate.TabIndex = 1;
			this.regenerate.Text = "Regenerate";
			this.regenerate.UseVisualStyleBackColor = true;
			// 
			// randomNumberGenerators
			// 
			this.randomNumberGenerators.DisplayMember = "Name";
			this.randomNumberGenerators.FormattingEnabled = true;
			this.randomNumberGenerators.Location = new System.Drawing.Point(8, 72);
			this.randomNumberGenerators.Name = "randomNumberGenerators";
			this.randomNumberGenerators.Size = new System.Drawing.Size(225, 21);
			this.randomNumberGenerators.TabIndex = 2;
			// 
			// sampleCount
			// 
			this.sampleCount.Location = new System.Drawing.Point(8, 112);
			this.sampleCount.Name = "sampleCount";
			this.sampleCount.Size = new System.Drawing.Size(225, 20);
			this.sampleCount.TabIndex = 3;
			this.sampleCount.Text = "49";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "RNG:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Sample count:";
			// 
			// sampleGenerators
			// 
			this.sampleGenerators.DisplayMember = "Name";
			this.sampleGenerators.FormattingEnabled = true;
			this.sampleGenerators.Location = new System.Drawing.Point(8, 32);
			this.sampleGenerators.Name = "sampleGenerators";
			this.sampleGenerators.Size = new System.Drawing.Size(225, 21);
			this.sampleGenerators.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Sample Generator:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.centerBiasDisplay);
			this.groupBox1.Controls.Add(this.centerBiasSlider);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.biasTowardsCenter);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.regenerate);
			this.groupBox1.Controls.Add(this.sampleCount);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.sampleGenerators);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.randomNumberGenerators);
			this.groupBox1.Location = new System.Drawing.Point(532, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(239, 313);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// centerBiasDisplay
			// 
			this.centerBiasDisplay.AutoSize = true;
			this.centerBiasDisplay.Location = new System.Drawing.Point(75, 163);
			this.centerBiasDisplay.Name = "centerBiasDisplay";
			this.centerBiasDisplay.Size = new System.Drawing.Size(22, 13);
			this.centerBiasDisplay.TabIndex = 12;
			this.centerBiasDisplay.Text = "1.0";
			// 
			// centerBiasSlider
			// 
			this.centerBiasSlider.Location = new System.Drawing.Point(6, 178);
			this.centerBiasSlider.Maximum = 500;
			this.centerBiasSlider.Name = "centerBiasSlider";
			this.centerBiasSlider.Size = new System.Drawing.Size(227, 42);
			this.centerBiasSlider.TabIndex = 11;
			this.centerBiasSlider.TickFrequency = 10;
			this.centerBiasSlider.Value = 100;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Bias amount:";
			// 
			// biasTowardsCenter
			// 
			this.biasTowardsCenter.AutoSize = true;
			this.biasTowardsCenter.Location = new System.Drawing.Point(8, 138);
			this.biasTowardsCenter.Name = "biasTowardsCenter";
			this.biasTowardsCenter.Size = new System.Drawing.Size(119, 17);
			this.biasTowardsCenter.TabIndex = 8;
			this.biasTowardsCenter.Text = "Bias towards center";
			this.biasTowardsCenter.UseVisualStyleBackColor = true;
			// 
			// VisualizerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(783, 534);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.imageContainer);
			this.Name = "VisualizerForm";
			this.Text = "Sampling visualizer";
			((System.ComponentModel.ISupportInitialize)(this.imageContainer)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.centerBiasSlider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox imageContainer;
		private System.Windows.Forms.Button regenerate;
		private System.Windows.Forms.ComboBox randomNumberGenerators;
		private System.Windows.Forms.TextBox sampleCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox sampleGenerators;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox biasTowardsCenter;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar centerBiasSlider;
		private System.Windows.Forms.Label centerBiasDisplay;


	}
}


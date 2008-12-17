namespace Kelly.Sampling.Visualization {
	partial class Form1 {
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
			((System.ComponentModel.ISupportInitialize)(this.imageContainer)).BeginInit();
			this.SuspendLayout();
			// 
			// imageContainer
			// 
			this.imageContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.imageContainer.Location = new System.Drawing.Point(12, 12);
			this.imageContainer.Name = "imageContainer";
			this.imageContainer.Size = new System.Drawing.Size(454, 471);
			this.imageContainer.TabIndex = 0;
			this.imageContainer.TabStop = false;
			// 
			// regenerate
			// 
			this.regenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.regenerate.Location = new System.Drawing.Point(472, 98);
			this.regenerate.Name = "regenerate";
			this.regenerate.Size = new System.Drawing.Size(167, 23);
			this.regenerate.TabIndex = 1;
			this.regenerate.Text = "Regenerate";
			this.regenerate.UseVisualStyleBackColor = true;
			// 
			// randomNumberGenerators
			// 
			this.randomNumberGenerators.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.randomNumberGenerators.DisplayMember = "Name";
			this.randomNumberGenerators.FormattingEnabled = true;
			this.randomNumberGenerators.Location = new System.Drawing.Point(472, 28);
			this.randomNumberGenerators.Name = "randomNumberGenerators";
			this.randomNumberGenerators.Size = new System.Drawing.Size(240, 21);
			this.randomNumberGenerators.TabIndex = 2;
			// 
			// sampleCount
			// 
			this.sampleCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sampleCount.Location = new System.Drawing.Point(472, 70);
			this.sampleCount.Name = "sampleCount";
			this.sampleCount.Size = new System.Drawing.Size(167, 20);
			this.sampleCount.TabIndex = 3;
			this.sampleCount.Text = "1000";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(472, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "RNG:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(472, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Sample count:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(720, 495);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.sampleCount);
			this.Controls.Add(this.randomNumberGenerators);
			this.Controls.Add(this.regenerate);
			this.Controls.Add(this.imageContainer);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.imageContainer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox imageContainer;
		private System.Windows.Forms.Button regenerate;
		private System.Windows.Forms.ComboBox randomNumberGenerators;
		private System.Windows.Forms.TextBox sampleCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;


	}
}


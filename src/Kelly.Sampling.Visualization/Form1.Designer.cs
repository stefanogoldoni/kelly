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
			this._image = new System.Windows.Forms.PictureBox();
			this._sampleGenerators = new System.Windows.Forms.ComboBox();
			this._randomNumberGenerators = new System.Windows.Forms.ComboBox();
			this._regenerate = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this._image)).BeginInit();
			this.SuspendLayout();
			// 
			// _image
			// 
			this._image.Location = new System.Drawing.Point(12, 153);
			this._image.Name = "_image";
			this._image.Size = new System.Drawing.Size(300, 300);
			this._image.TabIndex = 0;
			this._image.TabStop = false;
			// 
			// _sampleGenerators
			// 
			this._sampleGenerators.FormattingEnabled = true;
			this._sampleGenerators.Location = new System.Drawing.Point(12, 13);
			this._sampleGenerators.Name = "_sampleGenerators";
			this._sampleGenerators.Size = new System.Drawing.Size(300, 21);
			this._sampleGenerators.TabIndex = 1;
			// 
			// _randomNumberGenerators
			// 
			this._randomNumberGenerators.FormattingEnabled = true;
			this._randomNumberGenerators.Location = new System.Drawing.Point(13, 41);
			this._randomNumberGenerators.Name = "_randomNumberGenerators";
			this._randomNumberGenerators.Size = new System.Drawing.Size(299, 21);
			this._randomNumberGenerators.TabIndex = 2;
			// 
			// _regenerate
			// 
			this._regenerate.Location = new System.Drawing.Point(12, 69);
			this._regenerate.Name = "_regenerate";
			this._regenerate.Size = new System.Drawing.Size(75, 23);
			this._regenerate.TabIndex = 3;
			this._regenerate.Text = "Regenerate";
			this._regenerate.UseVisualStyleBackColor = true;
			this._regenerate.Click += new System.EventHandler(this._regenerate_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 465);
			this.Controls.Add(this._regenerate);
			this.Controls.Add(this._randomNumberGenerators);
			this.Controls.Add(this._sampleGenerators);
			this.Controls.Add(this._image);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this._image)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox _image;
		private System.Windows.Forms.ComboBox _sampleGenerators;
		private System.Windows.Forms.ComboBox _randomNumberGenerators;
		private System.Windows.Forms.Button _regenerate;

	}
}


namespace Kelly.Visualization {
	partial class VisualizationForm {
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
			this.result = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
			this.SuspendLayout();
			// 
			// result
			// 
			this.result.Location = new System.Drawing.Point(13, 13);
			this.result.Name = "result";
			this.result.Size = new System.Drawing.Size(640, 480);
			this.result.TabIndex = 0;
			this.result.TabStop = false;
			// 
			// VisualizationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(665, 501);
			this.Controls.Add(this.result);
			this.Name = "VisualizationForm";
			this.Text = "Rendering Visualization";
			((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox result;
	}
}


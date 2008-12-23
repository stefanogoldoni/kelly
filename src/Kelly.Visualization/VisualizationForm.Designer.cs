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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.samplesPerPixel = new System.Windows.Forms.TextBox();
			this.RenderButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.saveDialog = new System.Windows.Forms.SaveFileDialog();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.renderTime = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.result)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// result
			// 
			this.result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.result.Location = new System.Drawing.Point(13, 13);
			this.result.Name = "result";
			this.result.Size = new System.Drawing.Size(300, 300);
			this.result.TabIndex = 0;
			this.result.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.samplesPerPixel);
			this.groupBox1.Controls.Add(this.RenderButton);
			this.groupBox1.Controls.Add(this.SaveButton);
			this.groupBox1.Location = new System.Drawing.Point(321, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(279, 158);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Samples per pixel:";
			// 
			// samplesPerPixel
			// 
			this.samplesPerPixel.Location = new System.Drawing.Point(104, 19);
			this.samplesPerPixel.Name = "samplesPerPixel";
			this.samplesPerPixel.Size = new System.Drawing.Size(100, 20);
			this.samplesPerPixel.TabIndex = 2;
			this.samplesPerPixel.Text = "1";
			// 
			// RenderButton
			// 
			this.RenderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RenderButton.Location = new System.Drawing.Point(9, 124);
			this.RenderButton.Name = "RenderButton";
			this.RenderButton.Size = new System.Drawing.Size(133, 23);
			this.RenderButton.TabIndex = 1;
			this.RenderButton.Text = "Render ";
			this.RenderButton.UseVisualStyleBackColor = true;
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SaveButton.Location = new System.Drawing.Point(148, 124);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(125, 23);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save Image to File";
			this.SaveButton.UseVisualStyleBackColor = true;
			// 
			// saveDialog
			// 
			this.saveDialog.DefaultExt = "bmp";
			this.saveDialog.FileName = "output.bmp";
			this.saveDialog.Title = "Save rendered image to...";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.renderTime);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(321, 178);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(279, 135);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Rendering Data";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(33, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Time:";
			// 
			// renderTime
			// 
			this.renderTime.AutoSize = true;
			this.renderTime.Location = new System.Drawing.Point(47, 20);
			this.renderTime.Name = "renderTime";
			this.renderTime.Size = new System.Drawing.Size(0, 13);
			this.renderTime.TabIndex = 1;
			// 
			// VisualizationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(612, 316);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.result);
			this.Name = "VisualizationForm";
			this.Text = "Rendering Visualization";
			((System.ComponentModel.ISupportInitialize)(this.result)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox result;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.SaveFileDialog saveDialog;
		private System.Windows.Forms.Button RenderButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox samplesPerPixel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label renderTime;
		private System.Windows.Forms.Label label2;
	}
}


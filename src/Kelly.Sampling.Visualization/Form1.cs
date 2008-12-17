using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Kelly.Random;

namespace Kelly.Sampling.Visualization {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();

			randomNumberGenerators.DataSource = RngImplementations;

			regenerate.Click += WhenRegenerateClicked;
			RenderSamples();
		}

		private static IList<Type> RngImplementations {
			get {
				return (from t in typeof (IRandomNumberGenerator).Assembly.GetTypes()
				        where typeof (IRandomNumberGenerator).IsAssignableFrom(t) && !t.IsAbstract
				        select t).ToList();
			}
		}

		private void WhenRegenerateClicked(object sender, EventArgs e) {
			RenderSamples();
		}

		private void RenderSamples() {
			var target = new Bitmap(TargetSize.Width, TargetSize.Height);
			var generator = CreateGenerator();

			using (var graphics = Graphics.FromImage(target)) {
				graphics.SmoothingMode = SmoothingMode.HighQuality; 

				graphics.FillRectangle(Brushes.Black, 0, 0, target.Width, target.Height);

				foreach (var point in generator.GenerateSamples(SampleCount)) {
					graphics.FillEllipse(Brushes.White, point.X * target.Width, point.Y * target.Height, 1, 1);
				}
			}

			Target = target;
		}

		private Image Target {
			set { imageContainer.Image = value; }
		}

		private int SampleCount {
			get {
				int count;
				int.TryParse(sampleCount.Text, out count);
				return count;
			}
		}

		private Size TargetSize {
			get { return imageContainer.Size; }
		}

		private ISampleGenerator CreateGenerator() {
			return new RandomSampleGenerator((IRandomNumberGenerator)Activator.CreateInstance((Type) randomNumberGenerators.SelectedValue));
		}
	}
}

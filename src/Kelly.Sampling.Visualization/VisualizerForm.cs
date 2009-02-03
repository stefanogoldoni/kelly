using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Kelly.Random;

namespace Kelly.Sampling.Visualization {
	public partial class VisualizerForm : Form {
		public VisualizerForm() {
			InitializeComponent();

			randomNumberGenerators.DataSource = GetInterfaceImplementations<IRandomNumberGenerator>().ToList();

			sampleGenerators.DataSource =
				GetInterfaceImplementations<ISampleGenerator>()
				.Where(g => GetSampleGeneratorConstructor(g) != null)
				.ToList();

			centerBiasSlider.Maximum = MaxCenterBias * CenterBiasGranularity;
			centerBiasSlider.ValueChanged += BiasAmountChanged;

			SetupRenderEvents();
			RenderSamples();
		}

		private void SetupRenderEvents() {
			randomNumberGenerators.ValueMemberChanged += WhenNeedsRender;
			sampleGenerators.ValueMemberChanged += WhenNeedsRender;
			centerBiasSlider.ValueChanged += WhenNeedsRender;
			regenerate.Click += WhenNeedsRender;
			biasTowardsCenter.CheckStateChanged += WhenNeedsRender;
		}

		private void WhenNeedsRender(object sender, EventArgs args) {
			RenderSamples();
		}

		private void BiasAmountChanged(object sender, EventArgs e) {
			centerBiasDisplay.Text = CenterBiasAmount.ToString();
		}

		private const int MaxCenterBias = 5;
		private const int CenterBiasGranularity = 100;

		private static IEnumerable<Type> GetInterfaceImplementations<TInterface>() {
			return from t in typeof (TInterface).Assembly.GetTypes()
			       where typeof (TInterface).IsAssignableFrom(t) && !t.IsAbstract
			       select t;
		}

		private void RenderSamples() {
			var target = new Bitmap(TargetSize.Width, TargetSize.Height);
			var generator = CreateGenerator();

			using (var graphics = Graphics.FromImage(target)) {
				graphics.SmoothingMode = SmoothingMode.HighQuality; 

				graphics.FillRectangle(Brushes.Black, 0, 0, target.Width, target.Height);

				foreach (var point in generator.GenerateSamples(SampleCount)) {
				    graphics.FillEllipse(
						Brushes.White, 
						(float) (point.X * (target.Width - 1)), 
						(float) (point.Y * (target.Height - 1)), 
						5, 
						5);
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

		private double CenterBiasAmount {
			get {
				return centerBiasSlider.Value / (double)CenterBiasGranularity;
			}
		}

		private Size TargetSize {
			get { return imageContainer.Size; }
		}

		private static ConstructorInfo GetSampleGeneratorConstructor(Type sampleGeneratorType) {
			return sampleGeneratorType.GetConstructor(Type.EmptyTypes)
				?? sampleGeneratorType.GetConstructor(new[] { typeof(IRandomNumberGenerator) });
		}

		private ISampleGenerator CreateGenerator() {
			var sampleGeneratorType = ((Type) sampleGenerators.SelectedValue);

			var constructor = GetSampleGeneratorConstructor(sampleGeneratorType);

			if (constructor == null) {
				throw new Exception(
					string.Format("No suitable constrcutor found on \"{0}\"", sampleGeneratorType));
			}

			var parameters = constructor.GetParameters().Length == 1
			                 	? new[] {Activator.CreateInstance((Type) randomNumberGenerators.SelectedValue)}
			                 	: new object[] {};

			var generator = (ISampleGenerator)Activator.CreateInstance((Type)sampleGenerators.SelectedValue, parameters);

			return biasTowardsCenter.Checked
				? new CenterBiasedSampleGenerator(generator, CenterBiasAmount) 
				: generator;
		}
	}
}

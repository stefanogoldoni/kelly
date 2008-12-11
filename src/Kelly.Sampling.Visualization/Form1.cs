using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Castle.Core;
using Kelly.Math;
using Castle.Windsor;
using Kelly.Random;

namespace Kelly.Sampling.Visualization {
	public partial class Form1 : Form {
		public WindsorContainer IoC { get; set; }

		public Form1() {
			InitializeComponent();

			var generatorImplementations = GetSampleGeneratorImplementations().ToArray();
			_sampleGenerators.DataSource = generatorImplementations.Select(type => type.FullName).ToArray();

			_image.Image = new Bitmap(_image.Width, _image.Height);

			IoC = new WindsorContainer();

			foreach(var generator in generatorImplementations) {
				IoC.AddComponent(generator.FullName, typeof(ISampleGenerator), generator);
			}


			var rngImplementations = GetRngImplementations();
			foreach(var rng in rngImplementations) {
				IoC.AddComponent(rng.FullName, typeof (IRandomNumberGenerator), rng);
			}

			_randomNumberGenerators.DataSource = rngImplementations.Select(type => type.FullName);
		}

		private static void RenderSamples(ISampleGenerator generator, int count, Image target) {
			using (var graphics = Graphics.FromImage(target)) {
				graphics.FillRectangle(Brushes.Black, 0, 0, target.Width, target.Height);

				foreach (var point in generator.GenerateSamples(count)) {
					graphics.DrawRectangle(Pens.White, point.X * target.Width, point.Y * target.Height, 1, 1);
				}
			}
		}

		private static IEnumerable<Type> GetSampleGeneratorImplementations() {
			return from type in typeof (ISampleGenerator).Assembly.GetTypes()
			       where !type.IsAbstract && typeof (ISampleGenerator).IsAssignableFrom(type)
			       select type;
		}

		private static IEnumerable<Type> GetRngImplementations() {
			return from type in typeof(IRandomNumberGenerator).Assembly.GetTypes()
				   where !type.IsAbstract && typeof(IRandomNumberGenerator).IsAssignableFrom(type)
				   select type;			
		}

		private void Regenerate() {
			RenderSamples(IoC.Resolve<ISampleGenerator>((string)_sampleGenerators.SelectedValue), 1000, _image.Image);

			_image.Invalidate();
		}

		private void _regenerate_Click(object sender, EventArgs e) {
			Regenerate();
		}
	}
}

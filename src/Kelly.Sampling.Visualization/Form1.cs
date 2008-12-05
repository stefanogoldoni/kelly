using System;
using System.Collections.Generic;
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
			_sampleGenerators.DataSource = generatorImplementations.Select(type => type.Name).ToArray();

			_image.Image = new Bitmap(_image.Width, _image.Height);

			IoC = new WindsorContainer();

			foreach(var generator in generatorImplementations) {
				IoC.AddComponent(generator.FullName, typeof(ISampleGenerator), generator);
			}

			IoC.Kernel.AddComponent("IRandomNumberGenerator", typeof (IRandomNumberGenerator), typeof (NaiveRandomNumberGenerator), LifestyleType.Transient);

			RenderSamples(IoC.Resolve<ISampleGenerator>("Kelly.Sampling.RandomSampleGenerator"), 1000, _image.Image);
		}

		static void RenderSamples(ISampleGenerator generator, int count, Image target) {
			using (var graphics = Graphics.FromImage(target)) {
				graphics.FillRectangle(Brushes.Black, 0, 0, target.Width, target.Height);

				foreach (var point in generator.GenerateSamples(count)) {
					graphics.DrawRectangle(Pens.White, point.X * target.Width, point.Y * target.Height, 1, 1);
				}
			}
		}

		static IEnumerable<Type> GetSampleGeneratorImplementations() {
			return from type in typeof (ISampleGenerator).Assembly.GetTypes()
			       where !type.IsAbstract && typeof (ISampleGenerator).IsAssignableFrom(type)
			       select type;
		}
	}
}

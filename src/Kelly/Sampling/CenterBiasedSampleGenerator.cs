using System.Collections.Generic;
using Kelly.Math;

namespace Kelly.Sampling {
	public class CenterBiasedSampleGenerator : ISampleGenerator {
		private readonly ISampleGenerator _underlyingGenerator;

		public CenterBiasedSampleGenerator(ISampleGenerator underlyingGenerator) {
			_underlyingGenerator = underlyingGenerator;
		}

		public IEnumerable<Point2> GenerateSamples(int count) {
			foreach(var sample in _underlyingGenerator.GenerateSamples(count)) {
				var biased = sample - new Vector2(.5f, .5f);
				yield return new Point2(biased.X * biased.X, biased.Y * biased.Y);
			}
		}
	}
}

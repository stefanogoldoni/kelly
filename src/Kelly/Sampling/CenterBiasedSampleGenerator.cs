using System.Collections.Generic;
using Kelly.Math;

namespace Kelly.Sampling {
	public class CenterBiasedSampleGenerator : ISampleGenerator {
		private readonly ISampleGenerator _underlyingGenerator;
		private readonly float _bias;

		public CenterBiasedSampleGenerator(ISampleGenerator underlyingGenerator, float bias) {
			_underlyingGenerator = underlyingGenerator;
			_bias = bias;
		}

		public IEnumerable<Point2> GenerateSamples(int count) {
			foreach(var sample in _underlyingGenerator.GenerateSamples(count)) {
				var transformed = (sample - new Vector2(.5f, .5f)) * 2;

				yield return 
					new Point2(
						(float)System.Math.Pow(System.Math.Abs(transformed.X), _bias) * System.Math.Sign(transformed.X),
						(float)System.Math.Pow(System.Math.Abs(transformed.Y), _bias) * System.Math.Sign(transformed.Y)
					) / 2 + new Vector2(.5f, .5f);
			}
		}
	}
}

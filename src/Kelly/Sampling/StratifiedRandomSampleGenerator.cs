using System.Collections.Generic;
using Kelly.Math;
using Kelly.Random;

namespace Kelly.Sampling {
	/// <summary>
	/// TODO: can we somehow reuse code from StratifiedSampleGenerator here? They're ridiculously similar...
	/// </summary>
	public class StratifiedRandomSampleGenerator : ISampleGenerator {
		private readonly IRandomNumberGenerator _rng;

		public StratifiedRandomSampleGenerator(IRandomNumberGenerator rng) {
			_rng = rng;
		}

		public IEnumerable<Point2> GenerateSamples(int count) {
			var width = (int)System.Math.Sqrt(count);
			var sampleSize = 1f / width;

			foreach (var point in Point2.Grid(width, width)) {
				yield return (point + _rng.NextVector2()) * sampleSize;
			}
		}
	}
}
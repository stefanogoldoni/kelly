using System.Collections.Generic;
using System.Linq;
using Kelly.Math;
using Kelly.Random;

namespace Kelly.Sampling {
	public class RandomSampleGenerator : ISampleGenerator {
		private readonly IRandomNumberGenerator _rng;

		public RandomSampleGenerator(IRandomNumberGenerator rng) {
			_rng = rng;
		}

		public IEnumerable<Point2> GenerateSamples(int count) {
			return from x in Enumerable.Range(0, count)
			       select _rng.NextPoint2();
		}
	}
}
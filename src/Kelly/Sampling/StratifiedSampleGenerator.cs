using System.Collections.Generic;
using Kelly.Math;

namespace Kelly.Sampling {
	public class StratifiedSampleGenerator : ISampleGenerator {
		public IEnumerable<Point2> GenerateSamples(int count) {
			var width = (int)System.Math.Sqrt(count);
			var sampleSize = 1f / width;

			foreach (var point in Point2.Grid(width, width)) {
				yield return (point + new Vector2(.5f, .5f)) * sampleSize;
			}
		}
	}
}

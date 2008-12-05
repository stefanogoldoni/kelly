using System.Collections.Generic;
using Kelly.Math;

namespace Kelly.Sampling {
	public interface ISampleGenerator {
		IEnumerable<Point2> GenerateSamples(int count);
	}
}
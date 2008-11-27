using System.Collections.Generic;
using Kelly.Math;

namespace Kelly {
	public interface ISampleGenerator {
		IEnumerable<Point2> GenerateSamples(int count);
	}
}

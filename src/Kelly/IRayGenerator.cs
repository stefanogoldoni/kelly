using Kelly.Math;
using System.Collections.Generic;

namespace Kelly {
	public interface IRayGenerator {
		IEnumerable<Ray> GenerateRays(Pixel pixel);
	}
}

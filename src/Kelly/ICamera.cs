using System.Collections.Generic;
using Kelly.Math;

namespace Kelly {
	public interface ICamera {
		IEnumerable<Ray> GetRaysThroughPixel(Pixel pixel);
	}
}

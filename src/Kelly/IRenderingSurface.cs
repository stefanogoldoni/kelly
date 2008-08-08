using System.Collections;
using System.Collections.Generic;

namespace Kelly {
	public interface IRenderingSurface {
		IEnumerable<Pixel> Pixels { get; }

		void SetPixelColor(Pixel pixel, Color color);
	}
}

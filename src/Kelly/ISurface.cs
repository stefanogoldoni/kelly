using System.Collections;
using System.Collections.Generic;

namespace Kelly {
	public interface ISurface {
		IEnumerable<Pixel> Pixels { get; }

		void SetPixelColor(Pixel pixel, Color color);
	}
}

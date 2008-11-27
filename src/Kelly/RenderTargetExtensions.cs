using System.Collections.Generic;

namespace Kelly {
	public static class RenderTargetExtensions {
		public static IEnumerable<Pixel> GetPixels(this IRenderTarget target) {
			for(var x = 0; x < target.Width; x++) {
				for(var y = 0; y < target.Height; y++) {
					yield return new Pixel(x, y);
				}
			}
		}		
	}
}
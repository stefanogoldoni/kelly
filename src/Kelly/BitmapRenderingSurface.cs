using System.Collections.Generic;
using System.Drawing;
using Kelly.Imaging;

namespace Kelly {
	public class BitmapRenderingSurface : IRenderingSurface {
		public BitmapRenderingSurface(int width, int height) {
			_bitmap = new Bitmap(width, height);
		}

		private Bitmap _bitmap;

		public IEnumerable<Pixel> Pixels {
			get {
				for (var x = 0; x < _bitmap.Width; x++)
				for (var y = 0; y < _bitmap.Height; y++) {
					yield return new Pixel(x, y);
				}				
			}
		}

		public void SetPixelColor(Pixel pixel, Color color) {
			_bitmap.SetPixel(pixel.X, pixel.Y, color.ToDrawingColor());
		}
	}
}

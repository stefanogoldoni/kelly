using System.Drawing;
using System;

namespace Kelly {
	public class BitmapRenderTarget : IRenderTarget, IDisposable {
		public BitmapRenderTarget(int width, int height) {
			Bitmap = new Bitmap(width, height);
		}

		public Bitmap Bitmap { get; private set; }

		public int Width {
			get { return Bitmap.Width; }
		}

		public int Height {
			get { return Bitmap.Height; }
		}

		public void SetPixelColor(Pixel pixel, Color color) {
			pixel = ToBitmapSpace(pixel);
			Bitmap.SetPixel(pixel.X, pixel.Y, color.ToDrawingColor());
		}

		private Pixel ToBitmapSpace(Pixel pixel) {
			// we have to transform to the correct space
			// GDI coordinates start at the top left, ours start at bottom left
			return new Pixel(pixel.X, Height - 1 - pixel.Y);
		}

		public void Dispose() {
			if (Bitmap != null) {
				Bitmap.Dispose();
				Bitmap = null;
			}
		}
	}
}

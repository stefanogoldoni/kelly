using System.Drawing;
using Kelly.Imaging;

namespace Kelly {
	public class BitmapRenderTarget : IRenderTarget {
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
			Bitmap.SetPixel(pixel.X, pixel.Y, color.ToDrawingColor());
		}
	}
}

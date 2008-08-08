using System.Drawing;

namespace Kelly.Imaging {
	public class BitmapImage : IImage {
		public BitmapImage(int width, int height) {
			_bitmap = new Bitmap(width, height);
		}

		private Bitmap _bitmap;

		public Color GetPixelColor(int x, int y) {
			return _bitmap.GetPixel(x, y).ToKellyColor();
		}

		public void SetPixelColor(int x, int y, Color color) {
			_bitmap.SetPixel(x, y, color.ToDrawingColor());
		}
	}
}

namespace Kelly {
	public class MemoryRenderTarget : IRenderTarget {
		public MemoryRenderTarget(int width, int height) {
			Width = width;
			Height = height;

			Pixels = new Color[Width, Height];
		}

		public Color[,] Pixels { get; private set; }

		public int Width { get; private set; }
		public int Height { get; private set; }

		public void SetPixelColor(Pixel pixel, Color color) {
			Pixels[pixel.X, pixel.Y] = color;
		}
	}
}

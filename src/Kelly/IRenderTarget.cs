namespace Kelly {
	public interface IRenderTarget {
		int Width { get; }
		int Height { get; }

		void SetPixelColor(Pixel pixel, Color color);
	}
}

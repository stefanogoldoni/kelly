namespace Kelly {
	public interface IRenderTarget {
		int Width { get; }
		int Height { get; }

		/// <summary>
		/// Sets the color of the specified pixel. Pixel coordinates start at the lower-left corner of the image.
		/// </summary>
		void SetPixelColor(Pixel pixel, Color color);
	}
}

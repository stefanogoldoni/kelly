
namespace Kelly.Imaging {
	public interface IImage {
		Color GetPixelColor(int x, int y);
		void SetPixelColor(int x, int y, Color color);
	}
}

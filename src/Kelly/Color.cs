
namespace Kelly {
	public class Color {
		public Color(float r, float g, float b) {
			R = r;
			G = g;
			B = b;
		}

		public float R, G, B;

		public static readonly Color Black = new Color(0f, 0f, 0f);
	}
}

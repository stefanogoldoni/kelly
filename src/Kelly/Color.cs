
namespace Kelly {
	public class Color {
		public Color(float r, float g, float b) {
			R = r;
			G = g;
			B = b;
		}

		public float R, G, B;

		public static readonly Color Black = new Color(0, 0, 0);
		public static readonly Color White = new Color(1, 1, 1);
	}
}

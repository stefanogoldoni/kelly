
namespace Kelly {
	public class Color {
		public Color(double r, double g, double b) {
			R = r;
			G = g;
			B = b;
		}

		public double R, G, B;

		public static readonly Color Black = new Color(0, 0, 0);
		public static readonly Color White = new Color(1, 1, 1);
	}
}

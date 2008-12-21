using System.Diagnostics;

namespace Kelly {
	[DebuggerDisplay("{ToString()}")]
	public class Color {
		public Color(double r, double g, double b) {
			R = r;
			G = g;
			B = b;
		}

		public readonly double R, G, B;

		public static readonly Color Black = new Color(0, 0, 0);
		public static readonly Color White = new Color(1, 1, 1);

		public static readonly Color Red	= new Color(1, 0, 0);
		public static readonly Color Green	= new Color(0, 1, 0);
		public static readonly Color Blue	= new Color(0, 0, 1);

		public static Color operator + (Color left, Color right) {
			return new Color(left.R + right.R, left.G + right.G, left.B + right.B);
		}

		public static Color operator / (Color color, double scalar) {
			return new Color(color.R / scalar, color.G / scalar, color.B / scalar);
		}

		public override string ToString() {
			return string.Format("({0}, {1}, {2})", R, G, B);
		}
	}
}

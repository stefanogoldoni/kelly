using System.Diagnostics;

namespace Kelly.Math {
	[DebuggerDisplay("({X}, {Y})")]
	public class Vector2 {
		public Vector2(double x, double y) {
			X = x;
			Y = y;
		}

		public double X { get; private set; }
		public double Y { get; private set; }

		public static Vector2 operator *(Vector2 vector, double scalar) {
			return new Vector2(vector.X * scalar, vector.Y * scalar);
		}

		public double SquaredLength {
			get { return X * X + Y * Y; }
		}

		public double Length {
			get { return System.Math.Sqrt(SquaredLength); }
		}
	}
}

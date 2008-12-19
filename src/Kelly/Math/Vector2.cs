using System.Diagnostics;

namespace Kelly.Math {
	[DebuggerDisplay("({X}, {Y})")]
	public class Vector2 {
		public Vector2(float x, float y) {
			X = x;
			Y = y;
		}

		public float X { get; private set; }
		public float Y { get; private set; }

		public static Vector2 operator *(Vector2 vector, float scalar) {
			return new Vector2(vector.X * scalar, vector.Y * scalar);
		}

		public float SquaredLength {
			get { return X * X + Y * Y; }
		}

		public float Length {
			get { return (float)System.Math.Sqrt(SquaredLength); }
		}
	}
}

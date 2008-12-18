using System.Collections.Generic;

namespace Kelly.Math {
	public class Point2 {
		public Point2(float x, float y) {
			X = x;
			Y = y;
		}

		public float X { get; private set; }
		public float Y { get; private set; }

		public static Point2 operator +(Point2 left, Vector2 right) {
			return new Point2(left.X + right.X, left.Y + right.Y);
		}

		public static Point2 operator -(Point2 left, Vector2 right) {
			return new Point2(left.X - right.X, left.Y - right.Y);
		}

		public static Point2 operator *(Point2 point, float scalar) {
			return new Point2(point.X * scalar, point.Y * scalar);
		}

		public static Point2 operator /(Point2 point, float scalar) {
			return new Point2(point.X / scalar, point.Y / scalar);
		}

		public static IEnumerable<Point2> Grid(int width, int height) {
			for(var x = 0; x < width; x++) {
				for (var y = 0; y < height; y++) {
					yield return new Point2(x, y);
				}
			}
		}
	}
}

using System.Collections.Generic;
using System.Diagnostics;

namespace Kelly.Math {
	[DebuggerDisplay("({X}, {Y})")]
	public class Point2 {
		public Point2(double x, double y) {
			X = x;
			Y = y;
		}

		public double X { get; private set; }
		public double Y { get; private set; }

		public static double DistanceBetween(Point2 x, Point2 y) {
			return (x - y).Length;
		}

		public static Vector2 operator-(Point2 left, Point2 right) {
			return new Vector2(left.X - right.X, left.Y - right.Y);
		}

		public static Point2 operator +(Point2 left, Vector2 right) {
			return new Point2(left.X + right.X, left.Y + right.Y);
		}

		public static Point2 operator -(Point2 left, Vector2 right) {
			return new Point2(left.X - right.X, left.Y - right.Y);
		}

		public static Point2 operator *(Point2 point, double scalar) {
			return new Point2(point.X * scalar, point.Y * scalar);
		}

		public static Point2 operator /(Point2 point, double scalar) {
			return new Point2(point.X / scalar, point.Y / scalar);
		}

		public static IEnumerable<Point2> Grid(int width, int height) {
			for(var x = 0; x < width; x++) {
				for (var y = 0; y < height; y++) {
					yield return new Point2(x, y);
				}
			}
		}

		public static readonly Point2 Zero = new Point2(0, 0);
	}
}

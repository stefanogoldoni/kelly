using System;
using System.Diagnostics;

namespace Kelly.Math {
	[Serializable, DebuggerDisplay("{ToString()}")]
	public struct Point {
		public Point(double x, double y, double z) {
			_x = x;
			_y = y;
			_z = z;
		}

		public readonly double _x, _y, _z;

		public double X {
			get { return _x; }
		}

		public double Y {
			get { return _y; }
		}

		public double Z {
			get { return _z; }
		}

		public Vector ToVector() {
			return new Vector(X, Y, Z);
		}

		public static Vector operator -(Point x, Point y) {
			return new Vector(
				x.X - y.X,
				x.Y - y.Y,
				x.Z - y.Z
			);
		}

		public static Point operator +(Point x, Vector y) {
			return new Point(
				x.X + y.X,
				x.Y + y.Y,
				x.Z + y.Z
			);
		}

		public static readonly Point Zero = new Point(0, 0, 0);

		public override string ToString() {
			return string.Format("({0}, {1}, {2})", X, Y, Z);
		}
	}
}

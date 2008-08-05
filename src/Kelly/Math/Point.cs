using System.Diagnostics;

namespace Kelly.Math {
	[DebuggerDisplay("({X}, {Y}, {Z})")]
	public struct Point {
		public Point(float x, float y, float z) {
			_x = x;
			_y = y;
			_z = z;
		}

		public readonly float _x, _y, _z;

		public float X {
			get { return _x; }
		}

		public float Y {
			get { return _y; }
		}

		public float Z {
			get { return _z; }
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
	}
}

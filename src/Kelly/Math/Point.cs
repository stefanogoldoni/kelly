using System;
using System.Diagnostics;

namespace Kelly.Math {
	[Serializable, DebuggerDisplay("{ToString()}")]
	public partial struct Point {
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

		public override string ToString() {
			return string.Format("({0}, {1}, {2})", X, Y, Z);
		}

		public static readonly Point Zero = new Point(0, 0, 0);
	}
}

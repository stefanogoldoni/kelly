using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Kelly.Math {
	[DebuggerDisplay("{ToString()}")]
	public partial struct Vector {
		public Vector(double x, double y, double z) {
			_x = x;
			_y = y;
			_z = z;
		}

		private readonly double _x, _y, _z;

		public double X {
			get { return _x; }
		}

		public double Y {
			get { return _y; }
		}

		public double Z {
			get { return _z; }
		}

		public double SquaredLength {
			get { return DotProduct(this, this); }
		}

		public double Length {
			get { return System.Math.Sqrt(SquaredLength); }
		}

		public Vector Scale(double s) {
			return new Vector(X * s, Y * s, Z * s);
		}

		public bool IsUnit {
			get { return EpsilonComparer.Compare(SquaredLength, 1) == 0; }
		}

		[IndexerName("Element")]
		public double this[Axis axis] {
			get {
				if (axis == Axis.X)
					return X;

				if (axis == Axis.Y)
					return Y;

				return Z;
			}
		}

		public Axis LongestAxis {
			get {
				if (X > Y && X > Z)
					return Axis.X;

				if (Y > Z)
					return Axis.Y;

				return Axis.Z;
			}
		}

		public Vector ToUnitVector() {
			return this / Length;
		}

		public override string ToString() {
			return string.Format("({0}, {1}, {2})", X, Y, Z);
		}
	}
}

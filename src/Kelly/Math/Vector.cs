using System.Diagnostics;

namespace Kelly.Math {
	[DebuggerDisplay("({X}, {Y}, {Z})")]
	public struct Vector {
		public Vector(float x, float y, float z) {
			_x = x;
			_y = y;
			_z = z;
		}

		private readonly float _x, _y, _z;

		public float X {
			get { return _x; }
		}

		public float Y {
			get { return _y; }
		}

		public float Z {
			get { return _z; }
		}

		public float SquaredLength {
			get { return DotProduct(this, this); }
		}

		public float Length {
			get { return (float)System.Math.Sqrt(SquaredLength); }
		}

		public Vector Scale(float s) {
			return new Vector(X * s, Y * s, Z * s);
		}

		public bool IsUnit {
			get { return SquaredLength == 1.0f; }
		}

		public Vector ToUnitVector() {
			return this / Length;
		}

		public static float DotProduct(Vector x, Vector y) {
			return x.X * y.X
				 + x.Y * y.Y
				 + x.Z * y.Z;
		}

		public static Vector CrossProduct(Vector left, Vector right) {
			return
				(left.Y * right.Z - left.Z * right.Y) * UnitX +
				(left.Z * right.X - left.X * right.Z) * UnitY +
				(left.X * right.Y - left.Y * right.X) * UnitZ;					
		}

		public static Vector operator -(Vector vector) {
			return new Vector(-vector.X, -vector.Y, -vector.Z);
		}

		public static Vector operator +(Vector left, Vector right) {
			return new Vector(
				left.X + right.X,
				left.Y + right.Y,
				left.Z + right.Z
			);
		}

		public static Vector operator -(Vector left, Vector right) {
			return new Vector(
				left.X - right.X,
				left.Y - right.Y,
				left.Z - right.Z
			);			
		}

		public static Vector operator *(Vector vector, float scalar) {
			return new Vector(
				vector.X * scalar,
				vector.Y * scalar,
				vector.Z * scalar);
		}

		public static Vector operator *(float scalar, Vector vector) {
			return vector * scalar;
		}

		public static Vector operator /(Vector vector, float scalar) {
			return new Vector(
				vector.X / scalar, 
				vector.Y / scalar, 
				vector.Z / scalar);
		}

		public static readonly Vector Zero = new Vector(0, 0, 0);
		public static readonly Vector UnitX = new Vector(1f, 0, 0);
		public static readonly Vector UnitY = new Vector(0, 1f, 0);
		public static readonly Vector UnitZ = new Vector(0, 0, 1f);
	}
}

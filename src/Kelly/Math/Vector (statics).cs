namespace Kelly.Math {
	public partial struct Vector {
		public static double DotProduct(Vector x, Vector y) {
			return x.X * y.X
				 + x.Y * y.Y
				 + x.Z * y.Z;
		}

		public static Vector CrossProduct(Vector left, Vector right) {
			return new Vector(
				(left.Y * right.Z - left.Z * right.Y),
				(left.Z * right.X - left.X * right.Z),
				(left.X * right.Y - left.Y * right.X));
		}

		public static readonly Vector Zero = new Vector(0, 0, 0);
		public static readonly Vector UnitX = new Vector(1f, 0, 0);
		public static readonly Vector UnitY = new Vector(0, 1f, 0);
		public static readonly Vector UnitZ = new Vector(0, 0, 1f);
	}
}

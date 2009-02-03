namespace Kelly.Math {
	public partial struct Vector {
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

		public static Vector operator *(Vector vector, double scalar) {
			return new Vector(
				vector.X * scalar,
				vector.Y * scalar,
				vector.Z * scalar);
		}

		public static Vector operator *(double scalar, Vector vector) {
			return vector * scalar;
		}

		public static Vector operator /(Vector vector, double scalar) {
			return new Vector(
				vector.X / scalar,
				vector.Y / scalar,
				vector.Z / scalar);
		}
	}
}

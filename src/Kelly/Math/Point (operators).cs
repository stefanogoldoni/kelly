namespace Kelly.Math {
	public partial struct Point {
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

		public static Point operator -(Point x, Vector y) {
			return new Point(
				x.X - y.X,
				x.Y - y.Y,
				x.Z - y.Z
				);
		}

		public static Point ElementsMax(Point x, Point y) {
			return new Point(
				System.Math.Max(x.X, y.X),
				System.Math.Max(x.Y, y.Y),
				System.Math.Max(x.Z, y.Z)
				);
		}

		public static Point ElementsMin(Point x, Point y) {
			return new Point(
				System.Math.Min(x.X, y.X),
				System.Math.Min(x.Y, y.Y),
				System.Math.Min(x.Z, y.Z)
				);
		}
	}
}

using Kelly.Math;

namespace Kelly.Geometry {
	public class Sphere : IIntersectable {
		public Sphere(Point position, double radius) {
			Position = position;
			Radius = radius;
		}

		public Point Position { get; private set; }
		public double Radius { get; private set; }

		public Intersection FindClosestIntersectionWith(Ray ray) {
			var between = ray.Origin - Position;

			var b = Vector.DotProduct(between, ray.Direction);
			var c = between.SquaredLength - (Radius * Radius);
			var d = b * b - c;

			if (d <= 0) {
				return null;
			}

			var distance = (b > 0) 
				? -b + System.Math.Sqrt(d) 
				: -b - System.Math.Sqrt(d);

			return new Intersection(ray, distance);
		}

		public AxisAlignedBoundingBox GetBoundingBox() {
			var vec = new Vector(Radius, Radius, Radius);
			return new AxisAlignedBoundingBox(Position - vec, Position + vec);
		}
	}
}

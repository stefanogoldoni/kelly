using Kelly.Math;

namespace Kelly.Geometry {
	public class Sphere : IIntersectable {
		public Sphere(Point position, float radius) {
			Position = position;
			Radius = radius;
		}

		public Point Position { get; private set; }
		public float Radius { get; private set; }

		public Intersection Intersects(Ray ray) {
			var between = ray.Origin - Position;

			var b = Vector.DotProduct(between, ray.Direction);
			var c = between.SquaredLength - (Radius * Radius);
			var d = b * b - c;

			if (d <= 0) {
				return Intersection.None;
			}

			var distance = (b > 0) 
				? -b + (float)System.Math.Sqrt(d) 
				: -b - (float)System.Math.Sqrt(d);

			return new Intersection(ray, distance);
		}
	}
}

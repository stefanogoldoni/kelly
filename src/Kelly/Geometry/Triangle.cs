using Kelly.Math;

namespace Kelly.Geometry {
	public class Triangle : IIntersectable {
		private readonly Point _a;
		private readonly Point _b;
		private readonly Point _c;

		public Triangle(Point a, Point b, Point c) {
			_a = a;
			_b = b;
			_c = c;
		}

		/// <summary>
		/// Performs ray-triangle intersection based on Moller-Trubmore 97
		/// </summary>
		public Intersection FindClosestIntersectionWith(Ray ray) {
			var translated = ray.Origin - _a;
			var edge1 = _b - _a;
			var edge2 = _c - _a;

			var p = Vector.CrossProduct(ray.Direction, edge2);
			var q = Vector.CrossProduct(translated, edge1);

			var determinant = Vector.DotProduct(p, edge1);

			if (determinant == 0) {
				return null;
			}

			var u = Vector.DotProduct(p, translated) / determinant;

			// u + v must be between 0 and 1, which means that u must also be
			if (u < 0d || u > 1d) {
				return null;
			}

			var v = Vector.DotProduct(q, ray.Direction) / determinant;

			if (v < 0d || u + v > 1d) {
				return null;
			}

			// distance = t in the original algorithm 
			var distance = Vector.DotProduct(q, edge2) / determinant;

			if (distance < 0d) {
				return null;
			}

			return new Intersection(ray, distance);
		}
	}
}

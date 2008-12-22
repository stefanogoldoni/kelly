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

		public Intersection FindClosestIntersectionWith(Ray ray) {
			throw new System.NotImplementedException();
		}
	}
}

using Kelly.Math;

namespace Kelly.Geometry {
	public class Intersection {
		public Intersection(Ray ray, float distance) {
			Ray = ray;
			Distance = distance;
		}

		public Ray Ray { get; private set; }
		public float Distance { get; private set; }

		public Point Point {
			get {
				return Ray.Origin + Ray.Direction.Scale(Distance);
			}
		}
	}
}

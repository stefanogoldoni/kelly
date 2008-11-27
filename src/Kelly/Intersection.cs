using Kelly.Math;
using Kelly.Materials;

namespace Kelly {
	public class Intersection {
		public Intersection(Ray ray, float distance) : this(ray, distance, null) {
		}

		public Intersection(Ray ray, float distance, IMaterial material) {
			Ray = ray;
			Distance = distance;
			Material = material;
		}

		public Ray Ray { get; private set; }
		public float Distance { get; private set; }
		public IMaterial Material { get; private set; }

		public Point Point {
			get {
				return Ray.Origin + Ray.Direction.Scale(Distance);
			}
		}

		public Color Color {
			get {
				return Material.GetColorAt(Point);
			}
		}

		public static Intersection None = new Intersection(null, float.PositiveInfinity, null);
	}
}

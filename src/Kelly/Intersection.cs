using Kelly.Math;
using Kelly.Materials;

namespace Kelly {
	public class Intersection {
		public Intersection(Ray ray, double distance) : this(ray, distance, null) {
		}

		public Intersection(Ray ray, double distance, IMaterial material) {
			Ray = ray;
			Distance = distance;
			Material = material;
		}

		public Ray Ray { get; private set; }
		public double Distance { get; private set; }
		public IMaterial Material { get; private set; }

		public Point Point {
			get {
				return Ray.Origin + (Ray.Direction * Distance);
			}
		}

		public Color Color {
			get {
				return Material == null
				       	? Color.White
				       	: Material.GetColorAt(Point);
			}
		}

		public Intersection WithMaterial(IMaterial material) {
			return new Intersection(Ray, Distance, material);
		}
	}
}

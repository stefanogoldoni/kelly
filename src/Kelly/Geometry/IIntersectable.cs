using Kelly.Math;

namespace Kelly.Geometry {
	public interface IIntersectable {
		Intersection IntersectWith(Ray ray);
	}
}

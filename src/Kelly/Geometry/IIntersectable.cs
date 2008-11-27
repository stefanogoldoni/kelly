using Kelly.Math;

namespace Kelly.Geometry {
	public interface IIntersectable {
		Intersection Intersects(Ray ray);
	}
}

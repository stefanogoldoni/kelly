using Kelly.Math;

namespace Kelly {
	public interface IIntersectable {
		Intersection Intersects(Ray ray);
	}
}
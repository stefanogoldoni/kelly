using Kelly.Math;

namespace Kelly.Geometry {
	public interface IIntersectable {
		bool IntersectWith(Ray ray, out float distance);
	}
}

using Kelly.Math;

namespace Kelly {
	public interface IIntersectable {
		Intersection FindClosestIntersectionWith(Ray ray);

		AxisAlignedBoundingBox GetBoundingBox();
	}
}
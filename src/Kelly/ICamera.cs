using Kelly.Math;

namespace Kelly {
	public interface ICamera {
		Ray CreateRayThroughImagePlane(Point2 point);

		Point2 FindIntersectionWithImagePlane(Ray ray);
	}
}

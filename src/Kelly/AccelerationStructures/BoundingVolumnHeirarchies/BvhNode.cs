using Kelly.Math;

namespace Kelly.AccelerationStructures.BoundingVolumnHeirarchies {
	public class BvhNode : IIntersectable {
		public BvhNode(IIntersectable left, IIntersectable right) {
			_left = left;
			_right = right;

			_leftBounds = left.GetBoundingBox();
			_rightBounds = right.GetBoundingBox();
		}
		
		public AxisAlignedBoundingBox Box { get; private set; }

		private readonly IIntersectable _left;
		private readonly IIntersectable _right;

		private readonly AxisAlignedBoundingBox _leftBounds;
		private readonly AxisAlignedBoundingBox _rightBounds;

		public Intersection FindClosestIntersectionWith(Ray ray) {
			Intersection closest = null;

			if (_leftBounds.IntersectsRay(ray, 0, double.PositiveInfinity)) {
				closest = _left.FindClosestIntersectionWith(ray);
			}
			
			if (_rightBounds.IntersectsRay(ray, 0, (closest != null) ? closest.Distance : double.PositiveInfinity)) {
				closest = Intersection.Closest(closest, _right.FindClosestIntersectionWith(ray));
			}

			return closest;
		}

		public AxisAlignedBoundingBox GetBoundingBox() {
			return AxisAlignedBoundingBox.Combine(_leftBounds, _rightBounds);
		}
	}
}
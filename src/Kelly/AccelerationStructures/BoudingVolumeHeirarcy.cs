using Kelly.Math;

namespace Kelly.AccelerationStructures {
	public class BoudingVolumeHeirarcy : IIntersectable {
		public BoudingVolumeHeirarcy(BoudingVolumeHeirarcy left, BoudingVolumeHeirarcy right) {
			_left = left;
			_right = right;
		}
		
		public AxisAlignedBoundingBox Box { get; private set; }

		private BoudingVolumeHeirarcy _left;
		private BoudingVolumeHeirarcy _right;

		public Intersection FindClosestIntersectionWith(Ray ray) {
			Intersection closest = null;

			if (_left.Box.IntersectsRay(ray, 0, double.PositiveInfinity)) {
				closest = _left.FindClosestIntersectionWith(ray);
			}
			
			if (_right.Box.IntersectsRay(ray, 0, (closest != null) ? closest.Distance : double.PositiveInfinity)) {
				closest = Intersection.Closest(closest, _right.FindClosestIntersectionWith(ray));
			}

			return closest;
		}
	}
}
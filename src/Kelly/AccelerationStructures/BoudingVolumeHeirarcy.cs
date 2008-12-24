using System;
using Kelly.Math;

namespace Kelly.AccelerationStructures {
	public class BoudingVolumeHeirarcy : IIntersectable {
		public AxisAlignedBoundingBox Box { get; private set; }

		private BoudingVolumeHeirarcy _left;
		private BoudingVolumeHeirarcy _right;

		public Intersection FindClosestIntersectionWithRay2(Ray ray) {
			
		}

		public Intersection FindClosestIntersectionWith(Ray ray) {
			double leftDistance;
			var intersectsLeft = _left.Box.IntersectsRay(ray, out leftDistance);

			double rightDistance;
			var intersectsRight = _right.Box.IntersectsRay(ray, out rightDistance);

			if (intersectsLeft && intersectsRight) {
				if (leftDistance < rightDistance) {
					return IntersectInOrder(ray, _left, rightDistance, _right);
				}

				return IntersectInOrder(ray, _right, leftDistance, _left);
			}
			
			if (intersectsLeft) {
				return _left.FindClosestIntersectionWith(ray);
			}

			return _right.FindClosestIntersectionWith(ray);
		}

		private static Intersection IntersectInOrder(Ray ray, BoudingVolumeHeirarcy first, double secondDistance, BoudingVolumeHeirarcy second) {
			var intersection = first.FindClosestIntersectionWith(ray);

			if (intersection == null) {
				return second.FindClosestIntersectionWith(ray);
			}

			if (intersection.Distance < secondDistance)
				return intersection;

			var secondIntersection = second.FindClosestIntersectionWith(ray);

			if (intersection.Distance < secondIntersection.Distance)
				return intersection;

			return secondIntersection;
		}
	}
}
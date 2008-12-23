using System;
using Kelly.Math;

namespace Kelly.AccelerationStructures {
	public class BoudingVolumeHeirarcy : IIntersectable {
		public AxisAlignedBoundingBox Box { get; private set; }

		private BoudingVolumeHeirarcy _left;
		private BoudingVolumeHeirarcy _right;

		public Intersection FindClosestIntersectionWith(Ray ray) {
			
			//var distanceToLeft = _left.Box.IntersectsRay()
			throw new NotImplementedException();
		}
	}
}
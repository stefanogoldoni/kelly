using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kelly.Geometry;
using Kelly.Math;

namespace Kelly {
	public class BoudingVolumeHeirarcy : IIntersectable {
		public AxisAlignedBoundingBox Box { get; private set; }

		private BoudingVolumeHeirarcy _left;
		private BoudingVolumeHeirarcy _right;

		public Intersection FindClosestIntersectionWith(Ray ray) {
			
			//var distanceToLeft = _left.Box.IntersectsRaySegment()
			throw new NotImplementedException();
		}
	}
}

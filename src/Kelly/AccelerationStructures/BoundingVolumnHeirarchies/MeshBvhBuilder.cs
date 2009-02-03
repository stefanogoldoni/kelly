using System;
using System.Collections.Generic;
using System.Linq;
using Kelly.Geometry;

namespace Kelly.AccelerationStructures.BoundingVolumnHeirarchies {
	public class MeshBvhBuilder {
		public BvhNode Build(Mesh mesh) {
			var rootBounds = mesh.GetBoundingBox();

			var splitAxis = rootBounds.Extents.LongestAxis;
			var splitAxisLength = rootBounds.Extents[splitAxis];

			//var splitPlane = splitAxisLength / 2;
			
			//return new BvhNode();
			throw new NotImplementedException();
		}

		public BvhNode Build(IEnumerable<Triangle> triangles) {
			if (triangles.Count() <= 2) {
				var array = triangles.ToArray();

				//return new BvhNode(array[0], array.Length == 2 ? (IIntersectable)array[1] : null);
			}

			throw new NotImplementedException();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using Kelly.Geometry;
using Kelly.Math;

namespace Kelly.AccelerationStructures.BoundingVolumnHeirarchies {
	public class MeshBvhBuilder {
		public BvhNode Build(Mesh mesh) {
			var rootBounds = mesh.GetBoundingBox();

			throw new NotImplementedException();
		}

		public BvhNode Build(IEnumerable<MeshTriangle> triangles) {
			if (triangles.Count() <= 2) {
				var array = triangles.ToArray();

				return new BvhNode(array[0], array.Length == 2 ? (IIntersectable)array[1] : null);
			}

			throw new NotImplementedException();
		}

		private Axis LongestAxisOf(AxisAlignedBoundingBox box) {
			var extents = box.Max - box.Min;

			if (extents.X > extents.Y && extents.X > extents.Z)
				return Axis.X;

			if (extents.Y > extents.X && extents.Y > extents.Z)
				return Axis.Y;

			return Axis.Z;
		}
	}
}
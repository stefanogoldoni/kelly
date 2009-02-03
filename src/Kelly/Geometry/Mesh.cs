using System;
using System.Collections.Generic;
using System.Linq;
using FrigginAwesome.Extensions;
using Kelly.Math;

namespace Kelly.Geometry {
	[Serializable]
	public class Mesh : IIntersectable {
		public Point[] Vertices { get; private set; }
		public MeshTriangle[] MeshTriangles { get; private set; }

		// temporary hack to make intersection a little bit faster
		private AxisAlignedBoundingBox _boundingBox;

		public Mesh(IEnumerable<Point> points, IEnumerable<MeshTriangle> triangles) {
			Vertices = points.ToArray();
			MeshTriangles = triangles.ToArray();
		}

		/// <summary>
		/// TODO: This completely negates the benefits of using meshes... we should ideally be using some kind of intersectable that has a backrefernce
		///			to its parent mesh and a MeshTriangle. Then we can reuse the MeshTriangle data even for intersections, etc.
		///			Would subclassing the Triangle class be a good way to handle this?
		/// </summary>
		private IEnumerable<Triangle> Triangles {
			get {
				return MeshTriangles
					.Select(tri => new Triangle(Vertices[tri.AIndex], Vertices[tri.BIndex], Vertices[tri.CIndex]));
			}
		}

		/// <summary>
		/// TODO: This method is BUTT SLOW. For now it just loops over all of the triangles in the mesh and returns the closest intersection...
		/// </summary>
		public Intersection FindClosestIntersectionWith(Ray ray) {
			if (_boundingBox == null) {
				_boundingBox = GetBoundingBox();
			}

			if (!_boundingBox.IntersectsRay(ray, 0, double.PositiveInfinity)) {
				return null;
			}

			return Triangles
				.Select(triangle => triangle.FindClosestIntersectionWith(ray))
				.WhereNotNull()
				.OrderBy(intersection => intersection.Distance)
				.FirstOrDefault();
		}

		public AxisAlignedBoundingBox GetBoundingBox() {
			return AxisAlignedBoundingBox.FromPoints(Vertices);
		}
	}
}

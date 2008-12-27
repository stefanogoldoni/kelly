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

		public Mesh(IEnumerable<Point> points, IEnumerable<MeshTriangle> triangles) {
			Vertices = points.ToArray();
			MeshTriangles = triangles.ToArray();
		}

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

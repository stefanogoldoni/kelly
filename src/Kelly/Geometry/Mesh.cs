using System;
using System.Collections.Generic;
using System.Linq;
using FrigginAwesome.Extensions;
using Kelly.Math;

namespace Kelly.Geometry {
	[Serializable]
	public class Mesh : IIntersectable {
		public Point[] Points { get; private set; }
		public MeshTriangle[] MeshTriangles { get; private set; }

		public Mesh(IEnumerable<Point> points, IEnumerable<MeshTriangle> triangles) {
			Points = points.ToArray();
			MeshTriangles = triangles.ToArray();
		}

		private IEnumerable<Triangle> Triangles {
			get {
				return MeshTriangles
					.Select(tri => new Triangle(Points[tri.AIndex], Points[tri.BIndex], Points[tri.CIndex]));
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
	}
}

using System;
using Kelly.Math;

namespace Kelly.Geometry {
	[Serializable]
	public struct MeshTriangle : IIntersectable {
		public readonly int AIndex;
		public readonly int BIndex;
		public readonly int CIndex;

		public readonly Mesh Mesh;

		public MeshTriangle(int aIndex, int bIndex, int cIndex, Mesh mesh) {
			AIndex = aIndex;
			BIndex = bIndex;
			CIndex = cIndex;

			Mesh = mesh;
		}

		public override string ToString() {
			return string.Format("({0}, {1}, {2})", AIndex, BIndex, CIndex);
		}

		public Triangle ToTriangle() {
			return new Triangle(Mesh.Vertices[AIndex], Mesh.Vertices[BIndex], Mesh.Vertices[CIndex]);
		}

		public Intersection FindClosestIntersectionWith(Ray ray) {
			return ToTriangle().FindClosestIntersectionWith(ray);
		}

		public AxisAlignedBoundingBox GetBoundingBox() {
			return ToTriangle().GetBoundingBox();
		}
	}
}
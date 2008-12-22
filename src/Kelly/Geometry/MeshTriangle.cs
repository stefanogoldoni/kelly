using System;

namespace Kelly.Geometry {
	[Serializable]
	public struct MeshTriangle {
		public readonly int AIndex;
		public readonly int BIndex;
		public readonly int CIndex;

		public MeshTriangle(int aIndex, int bIndex, int cIndex) {
			AIndex = aIndex;
			BIndex = bIndex;
			CIndex = cIndex;
		}

		public override string ToString() {
			return string.Format("({0}, {1}, {2})", AIndex, BIndex, CIndex);
		}
	}
}
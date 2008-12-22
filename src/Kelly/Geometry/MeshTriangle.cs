namespace Kelly.Geometry {
	public struct MeshTriangle {
		public readonly int AIndex;
		public readonly int BIndex;
		public readonly int CIndex;

		public MeshTriangle(int aIndex, int bIndex, int cIndex) {
			AIndex = aIndex;
			BIndex = bIndex;
			CIndex = cIndex;
		}
	}
}
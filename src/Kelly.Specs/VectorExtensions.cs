using Kelly.Math;

namespace Kelly.Specs {
	static class VectorExtensions {
		public static bool IsUnit(this Vector vector) {
			return EpsilonComparer.Compare(vector.SquaredLength, 1) == 0;
		}
	}
}

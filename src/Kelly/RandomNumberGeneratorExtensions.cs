using Kelly.Math;
using Kelly.Random;

namespace Kelly {
	public static class RandomNumberGeneratorExtensions {
		public static Vector2 NextVector2(this IRandomNumberGenerator rng) {
			return new Vector2(rng.Next(), rng.Next());
		}

		public static Point2 NextPoint2(this IRandomNumberGenerator rng) {
			return new Point2(rng.Next(), rng.Next());
		}
	}
}

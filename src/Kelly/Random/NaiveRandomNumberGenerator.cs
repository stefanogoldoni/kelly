using Kelly.Random;

namespace Kelly {
	public class NaiveRandomNumberGenerator : IRandomNumberGenerator {
		public NaiveRandomNumberGenerator() {
			_rng = new System.Random();
		}

		private readonly System.Random _rng;

		public float Next() {
			return (float)_rng.NextDouble();
		}
	}
}
using System;

namespace Kelly.Math {
	public class NaiveRandomNumberGenerator : IRandomNumberGenerator {
		public NaiveRandomNumberGenerator() {
			_rng = new Random();
		}

		private Random _rng;

		public float Next() {
			return (float)_rng.NextDouble();
		}
	}
}

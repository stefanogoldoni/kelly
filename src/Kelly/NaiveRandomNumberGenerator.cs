using System;

namespace Kelly {
	public class NaiveRandomNumberGenerator : IRandomNumberGenerator {
		public NaiveRandomNumberGenerator() {
			_rng = new Random();
		}

		private readonly Random _rng;

		public float Next() {
			return (float)_rng.NextDouble();
		}
	}
}
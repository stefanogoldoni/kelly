namespace Kelly.Random {
	public class SystemRandomNumberGenerator : IRandomNumberGenerator {
		public SystemRandomNumberGenerator() {
			_rng = new System.Random();
		}

		private readonly System.Random _rng;

		public double Next() {
			return _rng.NextDouble();
		}
	}
}
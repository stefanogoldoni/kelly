using System.Linq;
using Kelly.Math;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_comparing_two_matrices : EqualitySpecs<Matrix> {
		private static readonly System.Random _rng = new System.Random();
		
		protected override Matrix GetRandomInstance() {
			return new Matrix(
				Enumerable
					.Repeat(0f, 16)
					.Select(x => _rng.NextDouble() * 10));
		}

		protected override Matrix[] GetRandomInstancesThatAreEqual(int count) {
			var instance = GetRandomInstance();

			return Enumerable
				.Range(0, count)
				.Select(i => instance.Clone())
				.ToArray();
		}
	}
}
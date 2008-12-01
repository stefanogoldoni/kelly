using System;
using System.Linq;
using Kelly.Math;

namespace Kelly.Specs.Math {
	public partial class MatrixSpecs : EqualitySpecs<Matrix> {
		private static readonly Random _rng = new Random();

		public static Matrix CreateMatrixWithSequentialElements() {
			return new Matrix(Enumerable.Range(1, 16).Cast<float>());
		}

		protected override Matrix GetRandomInstance() {
			return new Matrix(
				Enumerable
					.Repeat(0f, 16)
					.Select(x => (float) _rng.NextDouble() * 10f));
		}

		protected override Matrix[] GetRandomInstancesThatAreEqual(int count) {
			var instance = GetRandomInstance();

			var array = new Matrix[count];

			for (var i = 0; i < array.Length; i++) {
				array[i] = instance.Clone();
			}

			return array;
		}
	}
}
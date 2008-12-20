using System.Collections.Generic;

namespace Kelly.Math {
	public class EpsilonComparer : IComparer<double>, IComparer<Vector> {
		private static readonly double MaxErrorDivisor = System.Math.Pow(10, 15);

		public int Compare(double x, double y) {
			var difference = x - y;
			var maxError = System.Math.Max(x, y) / MaxErrorDivisor;

			return System.Math.Abs(difference) < maxError
					? 0 
					: System.Math.Sign(difference);
		}

		public int Compare(Vector x, Vector y) {
			return Compare(x.X, y.X) * 100 + Compare(x.Y, y.Y) * 10 + Compare(x.Z, y.Z);
		}
	}
}

using System.Collections.Generic;

namespace Kelly.Math {
	public class EpsilonComparer : IComparer<double>, IComparer<Vector> {
		private EpsilonComparer() {
		}

		public static int Compare(double x, double y) {
			return DoubleComparer.Compare(x, y);
		}

		public static IComparer<double> DoubleComparer {
			get { return new EpsilonComparer(); }
		}

		public static IComparer<Vector> VectorComparer {
			get { return new EpsilonComparer(); }
		}

		public static readonly double MaxErrorMultiplier = 1.0 / System.Math.Pow(10, 15);

		int IComparer<double>.Compare(double x, double y) {
			if (x == y)
				return 0;

			var difference = x - y;
			var maxError = System.Math.Max(x, y) * MaxErrorMultiplier;

			// Hack to deal with issues comparing to 0
			if (x == 0 || y == 0) {
				if (System.Math.Abs(difference) < MaxErrorMultiplier) {
					return 0;
				}
			}
			else if (System.Math.Abs(difference) < maxError) {
				return 0;
			}

			return System.Math.Sign(difference);
		}

		int IComparer<Vector>.Compare(Vector x, Vector y) {
			return Compare(x.X, y.X) * 100 + Compare(x.Y, y.Y) * 10 + Compare(x.Z, y.Z);
		}
	}
}

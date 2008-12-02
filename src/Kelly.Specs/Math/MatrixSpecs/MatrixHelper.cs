using System.Linq;
using Kelly.Math;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class MatrixHelper {
		public static readonly Matrix SequentialMatrix = new Matrix(Enumerable.Range(1, 16).Cast<float>());
	}
}
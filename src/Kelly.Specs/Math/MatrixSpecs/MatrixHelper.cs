using System.Linq;
using Kelly.Math;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class MatrixHelper {
		// Cast<double>() would throw here as of 3.5 SP1
		//	See http://blogs.msdn.com/ed_maurer/archive/2008/02/16/breaking-change-in-linq-queries-using-explicitly-typed-range-variables.aspx
		public static readonly Matrix SequentialMatrix = new Matrix(Enumerable.Range(1, 16).Select(x => (double)x));
	}
}
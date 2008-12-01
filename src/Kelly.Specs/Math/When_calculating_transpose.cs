using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math {
	public partial class MatrixSpecs {
		[Fact]
		public void Transpose_of_identity_should_equal_identity() {
			Assert.Equal(Matrix.Identity, Matrix.Identity.Transpose());
		}

		[Fact]
		public void Columns_and_rows_should_become_interchanged() {
			var actualTranspose = MatrixSpecs.CreateMatrixWithSequentialElements().Transpose();

			var expectedTranspose = new Matrix(
				1, 5, 9, 13,
				2, 6, 10, 14,
				3, 7, 11, 15,
				4, 8, 12, 16
				);

			Assert.Equal(expectedTranspose, actualTranspose);
		}
	}
}
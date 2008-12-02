using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_transposing_a_matrix {
		[Fact]
		public void The_transpose_of_the_identity_matrix_should_equal_the_identity_matrix() {
			Assert.Equal(Matrix.Identity, Matrix.Identity.Transpose());
		}

		[Fact]
		public void The_resulting_matrix_should_contain_the_elements_of_the_original_matrix_with_the_rows_and_columns_interchanged() {
			var expectedTranspose = new Matrix(
				1, 5, 9, 13,
				2, 6, 10, 14,
				3, 7, 11, 15,
				4, 8, 12, 16
				);

			Assert.Equal(expectedTranspose, MatrixHelper.SequentialMatrix.Transpose());
		}
	}
}
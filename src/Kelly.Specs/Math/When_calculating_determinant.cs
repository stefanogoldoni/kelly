using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math {
	public partial class MatrixSpecs {
		[Fact]
		public void Determinant_of_zero_matrix_should_be_zero() {
			Assert.Equal(0f, Matrix.Zero.CalculateDeterminant());
		}

		[Fact]
		public void Determinant_of_identity_matrix_should_be_one() {
			Assert.Equal(1f, Matrix.Identity.CalculateDeterminant());
		}

		[Fact]
		public void Determinant_of_matrix_with_a_zero_row_should_be_zero() {
			Assert.Equal(0f,
			             new Matrix(
			             	0f, 0f, 0f, 0f,
			             	0f, 1f, 0f, 0f,
			             	0f, 0f, 1f, 0f,
			             	0f, 0f, 0f, 1f).CalculateDeterminant());
		}

		[Fact]
		public void Determinant_of_matrix_with_two_equal_rows_should_be_zero() {
			Assert.Equal(0f,
			             new Matrix(
			             	1f, 1f, 1f, 1f,
			             	1f, 1f, 1f, 1f,
			             	0f, 0f, 1f, 0f,
			             	0f, 0f, 0f, 1f).CalculateDeterminant());
		}

		[Fact]
		public void Determinant_of_matrix_with_two_equal_columns_should_be_zero() {
			Assert.Equal(0f,
			             new Matrix(
			             	1f, 1f, 0f, 0f,
			             	1f, 1f, 0f, 0f,
			             	1f, 1f, 1f, 0f,
			             	1f, 1f, 0f, 1f).CalculateDeterminant());
		}

		[Fact]
		public void Determinant_of_scaling_matrix_should_equal_all_of_the_axis_scalars_multiplied_together() {
			Assert.Equal(0f, Matrix.Scaling(0, 1, 1).CalculateDeterminant());
			Assert.Equal(0f, Matrix.Scaling(1, 0, 1).CalculateDeterminant());
			Assert.Equal(0f, Matrix.Scaling(1, 1, 0).CalculateDeterminant());

			Assert.Equal(1f, Matrix.Scaling(1f, 1f, 1f).CalculateDeterminant());
			Assert.Equal(2f, Matrix.Scaling(2f, 1f, 1f).CalculateDeterminant());
			Assert.Equal(8f, Matrix.Scaling(2f, 2f, 2f).CalculateDeterminant());
		}
	}
}
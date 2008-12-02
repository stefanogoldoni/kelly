using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_calculating_the_determinant_of_a_matrix {
		[Fact]
		public void The_detereminant_of_the_zero_matrix_is_zero() {
			Assert.Equal(0f, Matrix.Zero.CalculateDeterminant());
		}

		[Fact]
		public void The_determinant_of_the_identity_matrix_is_one() {
			Assert.Equal(1f, Matrix.Identity.CalculateDeterminant());
		}

		[Fact]
		public void The_determinant_of_a_matrix_with_a_zero_row_is_zero() {
			Assert.Equal(0f,
			             new Matrix(
			             	0f, 0f, 0f, 0f,
			             	0f, 1f, 0f, 0f,
			             	0f, 0f, 1f, 0f,
			             	0f, 0f, 0f, 1f).CalculateDeterminant());
		}

		[Fact]
		public void The_determinant_of_a_matrix_with_two_identical_rows_is_zero() {
			Assert.Equal(0f,
			             new Matrix(
			             	1f, 1f, 1f, 1f,
			             	1f, 1f, 1f, 1f,
			             	0f, 0f, 1f, 0f,
			             	0f, 0f, 0f, 1f).CalculateDeterminant());
		}

		[Fact]
		public void The_determinant_of_a_matrix_with_two_identical_columns_is_zero() {
			Assert.Equal(0f,
			             new Matrix(
			             	1f, 1f, 0f, 0f,
			             	1f, 1f, 0f, 0f,
			             	1f, 1f, 1f, 0f,
			             	1f, 1f, 0f, 1f).CalculateDeterminant());
		}

		[Fact]
		public void The_determinant_of_a_scaling_matrix_equals_the_axis_scalars_multiplied_together() {
			Assert.Equal(0f, Matrix.Scaling(0, 1, 1).CalculateDeterminant());
			Assert.Equal(0f, Matrix.Scaling(1, 0, 1).CalculateDeterminant());
			Assert.Equal(0f, Matrix.Scaling(1, 1, 0).CalculateDeterminant());

			Assert.Equal(1f, Matrix.Scaling(1f, 1f, 1f).CalculateDeterminant());
			Assert.Equal(2f, Matrix.Scaling(2f, 1f, 1f).CalculateDeterminant());
			Assert.Equal(8f, Matrix.Scaling(2f, 2f, 2f).CalculateDeterminant());
		}
	}
}
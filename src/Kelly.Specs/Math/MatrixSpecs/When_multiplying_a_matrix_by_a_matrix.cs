using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_multiplying_a_matrix_by_a_matrix {
		[Fact]
		public void The_result_is_the_right_matrix_when_the_left_matrix_is_the_identity_matrix() {
			var right = MatrixHelper.SequentialMatrix;
			Assert.Equal(right, Matrix.Identity * right);
		}

		[Fact]
		public void The_result_is_the_left_matrix_when_the_right_matrix_is_the_identity_matrix() {
			var left = MatrixHelper.SequentialMatrix;
			Assert.Equal(left, left * Matrix.Identity);
		}

		[Fact]
		public void The_result_is_the_identity_matrix_when_both_matrices_are_the_identity_matrix() {
			Assert.Equal(Matrix.Identity, Matrix.Identity * Matrix.Identity);
		}

		[Fact]
		public void The_result_is_the_zero_matrix_when_the_left_matrix_is_the_zero_matrix() {
			var right = MatrixHelper.SequentialMatrix;
			Assert.Equal(Matrix.Zero, Matrix.Zero * right);
		}

		[Fact]
		public void The_result_is_the_zero_matrix_when_the_right_matrix_is_the_zero_matrix() {
			var left = MatrixHelper.SequentialMatrix;
			Assert.Equal(Matrix.Zero, left * Matrix.Zero);
		}
	}
}

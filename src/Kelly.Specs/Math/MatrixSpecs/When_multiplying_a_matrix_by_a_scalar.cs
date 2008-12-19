using System.Linq;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_multiplying_a_matrix_by_a_scalar {
		[Fact]
		public void The_operation_is_commutative() {
			Assert.Equal(MatrixHelper.SequentialMatrix * 7, 7 * MatrixHelper.SequentialMatrix);
		}

		[Fact]
		public void The_result_is_the_zero_matrix_when_the_scalar_is_zero() {
			Assert.Equal(Matrix.Zero, MatrixHelper.SequentialMatrix * 0);
		}

		[Fact]
		public void The_result_is_the_original_matrix_when_the_scalar_is_one() {
			Assert.Equal(MatrixHelper.SequentialMatrix, MatrixHelper.SequentialMatrix * 1);
		}

		[Fact]
		public void The_result_is_the_zero_matrix_when_the_matrix_is_the_zero_matrix() {
			Assert.Equal(Matrix.Zero, Matrix.Zero * 1337);
		}

		[Fact]
		public void The_resulting_matrix_contains_all_of_the_original_elements_multiplied_by_the_scalar() {
			var original = MatrixHelper.SequentialMatrix;
			var scalar = 42f;
			var scaled = original * scalar;

			Assert.Equal(
				scaled.ToArray(), 
				original.Select(el => el * scalar).ToArray());
		}
	}
}

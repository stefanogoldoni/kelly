using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_inverting_a_matrix {
		[Fact]
		public void The_inverse_of_the_identity_matrix_is_the_identity_matrix() {
			Assert.Equal(Matrix.Identity, Matrix.Identity.Invert());
		}

		[Fact]
		public void A_matrix_multiplied_with_its_inverse_result_in_the_identity_matrix() {
			var matrix = new Matrix(
				1, 0, 0, 3,
				0, 2, 0, 5,
				0, 0, 4, 7,
				0, 0, 0, 1);

			Assert.Equal(Matrix.Identity, matrix * matrix.Invert());
		}
	}
}

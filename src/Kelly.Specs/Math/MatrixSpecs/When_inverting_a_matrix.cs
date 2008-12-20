using System;
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_inverting_a_matrix {
		[Fact]
		public void The_inverse_of_the_identity_matrix_is_the_identity_matrix() {
			Assert.Equal(Matrix.Identity, Matrix.Identity.Invert());
		}

		[Fact]
		public void A_matrix_multiplied_with_its_inverse_results_in_the_identity_matrix() {
			var matrix = new Matrix(
				1, 0, 0, 3,
				0, 2, 0, 5,
				0, 0, 4, 7,
				0, 0, 0, 1);

			Assert.Equal(Matrix.Identity, matrix * matrix.Invert());
		}

		[Fact]
		public void Multiplication_of_a_matrix_with_its_inverse_is_commutative() {
			var matrix = new Matrix(
				1, 0, 0, 3,
				0, 2, 0, 5,
				0, 0, 4, 7,
				0, 0, 0, 1);

			var inverse = matrix.Invert();
			Assert.Equal(matrix * inverse, inverse * matrix);
		}

		[Fact]
		public void Trying_to_invert_a_singular_matrix_causes_an_exception_to_be_thrown() {
			var matrix = new Matrix(
				0, 0, 0, 0,
				1, 2, 3, 4,
				5, 6, 7, 8,
				9, 1, 2, 3
				);

			Assert.Throws<Exception>(() => matrix.Invert());
		}
	}
}

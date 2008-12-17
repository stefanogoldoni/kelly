using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_multiplying_a_matrix_by_a_vector {
		[Fact]
		public void The_identity_matrix_should_result_in_the_same_vector() {
			var vector = new Vector(1, 2, 3);

			Assert.Equal(vector, Matrix.Identity * vector);
		}

		[Fact]
		public void The_zero_vector_should_result_in_the_zero_vector() {
			var matrix = new Matrix(
				1, 3, 4, 15,
				0, 5, 0, 2,
				0, 0, 3, 5,
				0, 0, 0, 1);

			Assert.Equal(Vector.Zero, matrix * Vector.Zero);
		}

		[Fact]
		public void The_zero_matrix_should_result_in_the_zero_vector() {
			Assert.Equal(Vector.Zero, Matrix.Zero * new Vector(1, 2, 3));
		}

		[Fact]
		public void A_scaling_matrix_should_scale_each_component_of_the_vector() {
			var matrix = new Matrix(
				1, 0, 0, 0,
				0, 2, 0, 0,
				0, 0, 3, 0,
				0, 0, 0, 1);

			Assert.Equal(new Vector(2, 6, 12), matrix * new Vector(2, 3, 4));
		}

		[Fact]
		public void A_translation_matrix_should_result_in_the_same_vector() {
			var vector = new Vector(1, 2, 3);

			var matrix = new Matrix(
				1, 0, 0, 1,
				0, 1, 0, 2,
				0, 0, 1, 3,
				0, 0, 0, 1);

			Assert.Equal(vector, matrix * vector);
		}
	}
}

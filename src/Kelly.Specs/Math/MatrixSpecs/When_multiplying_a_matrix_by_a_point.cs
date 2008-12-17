using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.MatrixSpecs {
	public class When_multiplying_a_matrix_by_a_point {
		[Fact]
		public void The_identity_matrix_should_result_in_the_same_point() {
			var point = new Point(1, 2, 3);

			Assert.Equal(point, Matrix.Identity * point);
		}

		[Fact]
		public void The_zero_matrix_should_result_in_the_zero_point() {
			Assert.Equal(Point.Zero, Matrix.Zero * new Point(1, 2, 3));
		}

		[Fact]
		public void A_scaling_matrix_should_scale_each_component_of_the_point() {
			var matrix = new Matrix(
				1, 0, 0, 0,
				0, 2, 0, 0,
				0, 0, 3, 0,
				0, 0, 0, 1);

			Assert.Equal(new Point(2, 6, 12), matrix * new Point(2, 3, 4));
		}

		[Fact]
		public void A_translation_matrix_should_translate_each_component_of_the_point() {
			var matrix = new Matrix(
				1, 0, 0, 1,
				0, 1, 0, 3,
				0, 0, 1, -2,
				0, 0, 0, 1);

			Assert.Equal(new Point(2, 5, 1), matrix * new Point(1, 2, 3));
		}
	}
}
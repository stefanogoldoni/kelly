using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_multiplying_a_vector_by_a_scalar {
		[Fact]
		public void The_operation_is_commutative() {
			var vector = new Vector(3, -49, 17);
			var scalar = 14.7f;

			Assert.Equal(vector * scalar, scalar * vector);
		}

		[Fact]
		public void The_result_is_the_vector_scaled_by_the_scalar() {
			Assert.Equal(
				new Vector(2, 4, 6),
				new Vector(1, 2, 3) * 2);

			Assert.Equal(
				new Vector(2, 0, 0),
				new Vector(1, 0, 0) * 2);

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(2, 2, 2) * .5f);
		}
	}
}
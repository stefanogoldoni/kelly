using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_dividing_a_vector_by_a_scalar {
		[Fact]
		public void The_results_is_the_vector_scaled_by_the_inverse_of_the_scalar() {
			Assert.Equal(
				new Vector(1, 0, 0),
				new Vector(5, 0, 0) / 5);

			Assert.Equal(
				new Vector(1, 1, 1),
				new Vector(5, 5, 5) / 5);

			Assert.Equal(
				new Vector(3, 2, 1),
				new Vector(39, 26, 13) / 13);
		}
	}
}

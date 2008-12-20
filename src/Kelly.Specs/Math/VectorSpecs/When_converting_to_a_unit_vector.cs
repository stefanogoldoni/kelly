using Kelly.Math;
using Xunit;
using Xunit.Extensions;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_converting_to_a_unit_vector {
		[Fact]
		public void The_zero_vector_results_in_a_NaN_vector() {
			Assert.Equal(
				new Vector(double.NaN, double.NaN, double.NaN), 
				Vector.Zero.ToUnitVector());
		}

		[Theory]
		[InlineData(1, 2, 3)]
		[InlineData(7, 0, 0)]
		[InlineData(0, 7, 0)]
		[InlineData(0, 0, 7)]
		[InlineData(.1, 0, 0)]
		[InlineData(0, .1, 0)]
		[InlineData(0, 0, .1)]
		[InlineData(.1, .02, .3)]
		public void The_result_for_a_nonzero_vector_is_a_unit_vector(double x, double y, double z) {
			Assert.True(new Vector(x, y, z).ToUnitVector().IsUnit);
		}		
		
		[Fact]
		public void The_result_is_a_vector_whos_dot_product_with_the_original_vector_equals_the_original_vectors_length() {
			var x = new Vector(10, 4.7f, -13);

			Assert.Equal(
				x.Length,
				Vector.DotProduct(x.ToUnitVector(), x), EpsilonComparer.DoubleComparer);
		}
	}
}
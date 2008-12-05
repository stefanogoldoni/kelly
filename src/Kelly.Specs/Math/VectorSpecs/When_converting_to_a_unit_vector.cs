using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class When_converting_to_a_unit_vector {
		[Fact]
		public void The_result_is_a_unit_vector() {
			Assert.True(new Vector(7, 0, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 7, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 0, 7).ToUnitVector().IsUnit);

			Assert.True(new Vector(.1f, 0, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, .1f, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 0, .1f).ToUnitVector().IsUnit);

			Assert.True(new Vector(.1f, .02f, .3f).ToUnitVector().IsUnit);
		}		
		
		[Fact]
		public void The_result_is_a_vector_whos_dot_product_with_the_original_vector_equals_the_original_vectors_length() {
			var x = new Vector(10, 4.7f, -13);

			Assert.Equal(
				x.Length,
				Vector.DotProduct(x.ToUnitVector(), x));
		}
	}
}
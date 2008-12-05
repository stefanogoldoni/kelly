using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class The_IsUnit_property {
		[Fact]
		public void Is_true_for_unit_vectors() {
			Assert.True(new Vector(1, 0, 0).IsUnit);
			Assert.True(new Vector(0, 1, 0).IsUnit);
			Assert.True(new Vector(0, 0, 1).IsUnit);
		}

		[Fact]
		public void Is_false_for_nonunit_vectors() {
			Assert.False(new Vector(1, 1, 0).IsUnit);
			Assert.False(new Vector(1, 0, 1).IsUnit);
			Assert.False(new Vector(0, 1, 1).IsUnit);

			Assert.False(new Vector(1.1f, 0, 0).IsUnit);
			Assert.False(new Vector(0, 1.1f, 0).IsUnit);
			Assert.False(new Vector(0, 0, 1.1f).IsUnit);

			Assert.False(new Vector(.9f, 0, 0).IsUnit);
			Assert.False(new Vector(0, .9f, 0).IsUnit);
			Assert.False(new Vector(0, 0, .9f).IsUnit);
		}		
	}
}
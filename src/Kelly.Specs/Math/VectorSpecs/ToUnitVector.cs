using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class ToUnitVector {
		[Fact]
		public void ReturnsUnitVector() {
			Assert.True(new Vector(7, 0, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 7, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 0, 7).ToUnitVector().IsUnit);

			Assert.True(new Vector(.1f, 0, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, .1f, 0).ToUnitVector().IsUnit);
			Assert.True(new Vector(0, 0, .1f).ToUnitVector().IsUnit);

			Assert.True(new Vector(.1f, .02f, .3f).ToUnitVector().IsUnit);
		}
	}
}
using Kelly.Math;
using Xunit;

namespace Kelly.Specs.Math.VectorSpecs {
	public class Constants {
		[Fact]
		public void StaticUnitVectorsAllHaveUnitLength() {
			Assert.True(Vector.UnitX.IsUnit);
			Assert.True(Vector.UnitY.IsUnit);
			Assert.True(Vector.UnitZ.IsUnit);
		}

		[Fact]
		public void ZeroVectorHasLenghOfZero() {
			Assert.Equal(
				0f,
				Vector.Zero.Length);
		}
	}
}